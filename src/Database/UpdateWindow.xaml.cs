using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;

namespace Scruppy.Database;
/// <summary>
/// Interaction logic for UpdateWindow.xaml
/// </summary>
public partial class UpdateWindow : Window
{
    private readonly Dictionary<string, string> _dirs = new()
    {
        { "_db",   Path.Combine(Directory.GetCurrentDirectory(), "AppData", "Database") },
        { "_icon", Path.Combine(Directory.GetCurrentDirectory(), "AppData", "Database", "Icon") },
        { "_tmp",  Path.Combine(Directory.GetCurrentDirectory(), "AppData", "Tmp") }
    };

    private readonly string _remoteDatabaseUrl = "https://metaforge.app/api/arc-raiders/";

    private readonly Dictionary<string, int> _remoteDatabaseDetail = new()
    {
        { "items",           11 }//,
        //{ "arcs",            0 },
        //{ "quests",          0 },
        //{ "game-map-data",   0 },
        //{ "event-timers",    0 },
        //{ "events-schedule", 0 },
        //{ "traders",         0 }

    };

    private static readonly HttpClient _http = new();

    /// <summary>Initializes a new instance of the <see cref="UpdateWindow"/> class.</summary>
    public UpdateWindow()
    {
        InitializeComponent();

        SetEventHandlers();

        ResetFramework();
    }

    private void ResetFramework()
    {
        foreach (var path in _dirs.Values)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, recursive: true);
            }

            Directory.CreateDirectory(path);
        }
    }

    /// <summary>Start the database update process for configured remote databases.</summary>
    /// <remarks>The method downloads pages and then combines them for each configured database.</remarks>
    private async Task UpdateDatabaseClickedAsync()
    {
        foreach ((string name, int pages) in _remoteDatabaseDetail)
        {
            await DownloadRemoteDatabaseAsync(name, pages).ConfigureAwait(false);
            await CombineDatabasePagesAsync(name, pages).ConfigureAwait(false);
        }
    }

    /// <summary>Download remote database pages to temporary files.</summary>
    /// <param name="databaseName">The database name.</param>
    /// <param name="databasePages">Number of pages.</param>
    private async Task DownloadRemoteDatabaseAsync(string databaseName, int databasePages)
    {
        for (int databasePage = 1; databasePage <= databasePages; databasePage++)
        {
            try
            {
                var remoteJson = await GetRemoteJsonAsync(databaseName, databasePage).ConfigureAwait(false);

                // Ensure filename matches what the Combine method expects (no leading underscore)
                var tmpFilePath = Path.Combine(_dirs["_tmp"], $"{databaseName}-page{databasePage}.json");

                await File.WriteAllTextAsync(tmpFilePath, remoteJson).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Dispatcher.Invoke(() => txbxUpdateStatus.Text = "Download failed: " + ex.Message);
            }
        }
    }

    /// <summary>Fetch a single page of remote JSON.</summary>
    /// <param name="databaseName">Database name.</param>
    /// <param name="databasePageNumber">Page number (1-based).</param>
    /// <returns>JSON content as string.</returns>
    private async Task<string> GetRemoteJsonAsync(string databaseName, int databasePageNumber)
    {
        var url = $"https://metaforge.app/api/arc-raiders/{databaseName}";

        if (databasePageNumber > 0)
        {
            url += $"?page={databasePageNumber}";
        }

        using var req = new HttpRequestMessage(HttpMethod.Get, url);
        using var resp = await _http.SendAsync(req, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
        resp.EnsureSuccessStatusCode();

        return await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
    }

    /// <summary>Combine downloaded page files into a single database JSON file.</summary>
    /// <param name="databaseName">The database name.</param>
    /// <param name="databasePages">Number of pages to combine.</param>
    private async Task CombineDatabasePagesAsync(string databaseName, int databasePages)
    {
        var databasePath = Path.Combine(_dirs["_db"], $"{databaseName}.json");

        // Do NOT call File.Create(databasePath) here — it leaves an open handle.
        var combinedArray = new JsonArray();

        for (int databasePage = 1; databasePage <= databasePages; databasePage++)
        {
            var databasePagePath = Path.Combine(_dirs["_tmp"], $"{databaseName}-page{databasePage}.json");

            if (!File.Exists(databasePagePath))
            {
                Dispatcher.Invoke(() => txbxUpdateStatus.Text = $"Missing page file: {databasePagePath}");
                continue;
            }

            var databasePageContent = await File.ReadAllTextAsync(databasePagePath).ConfigureAwait(false);

            using var databaseDoc = JsonDocument.Parse(databasePageContent);

            var databasePageData = databaseDoc.RootElement.GetProperty("data");

            foreach (var item in databasePageData.EnumerateArray())
            {
                var node = JsonNode.Parse(item.GetRawText());

                if (node is not null)
                {
                    combinedArray.Add(node);
                }
            }
        }

        var root = new JsonObject { ["data"] = combinedArray };
        var options = new JsonSerializerOptions { WriteIndented = true };

        await File.WriteAllTextAsync(databasePath, root.ToJsonString(options)).ConfigureAwait(false);
    }

    private async void Coolate()
    {

    }

    /* EVENT HANDLERS */

    private void SetEventHandlers()
    {
        btnUpdateDatabase.Click += btnUpdateDatabase_Clicked;
    }

    private async void btnUpdateDatabase_Clicked(object sender, RoutedEventArgs e) => await UpdateDatabaseClickedAsync();
}