using System.Net;
using Microsoft.Maui.Controls;
namespace Maui.Controls.Sample;

public partial class WebViewOptionsPage : ContentPage
{
	private WebViewViewModel _viewModel;
	public WebViewOptionsPage(WebViewViewModel viewModel)
	{
		var initialState = $"JavaScript: [{viewModel.JsEvaluationResult}]\n" +
			$"Cookies: {viewModel.Cookies?.Count ?? 0}\n" +
			$"Visible: {viewModel.IsVisible}\n" +
			$"Shadow: {viewModel.Shadow != null}\n" +
			$"Process terminated: [{viewModel.ProcessTerminatedStatus}]";
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
		InitialStateLabel.Text = initialState;
	}
	private async void ApplyButton_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
	private async void ResetWebView_Clicked(object sender, EventArgs e)
	{
		// A new WebView clears native navigation history without restarting the app.
		var previousPage = Navigation.NavigationStack[^2];
		var newPage = new WebViewControlMainPage(new WebViewViewModel());
		Navigation.InsertPageBefore(newPage, previousPage);
		Navigation.RemovePage(previousPage);
		await Navigation.PopAsync(false);
	}
	private void ShowDiagnostics_Clicked(object sender, EventArgs e)
	{
		_viewModel.IsDiagnosticsVisible = true;
	}
	private void OnHtmlSourceClicked(object sender, EventArgs e)
	{
		_viewModel.Source = new HtmlWebViewSource
		{
			Html = WebViewViewModel.DefaultHtml,
		};
	}
	private void OnMicrosoftUrlClicked(object sender, EventArgs e)
	{
		_viewModel.Source = new UrlWebViewSource
		{
			Url = "https://example.org"
		};
	}
	private void OnGithubUrlClicked(object sender, EventArgs e)
	{
		_viewModel.Source = new UrlWebViewSource
		{
			Url = "https://example.com"
		};
	}
	private void LoadMultiplePages_Clicked(object sender, EventArgs e)
	{
		_viewModel.Source = new HtmlWebViewSource
		{
			Html = @"
    <!DOCTYPE html>
    <html>
    <head>
        <title>Multiple Pages Navigation</title>
        <style>
            body { font-family: Arial; padding: 16px; line-height: 1.6; }
            h1 { color: #3366cc; }
            a {
                display: inline-block;
                margin: 10px 5px;
                padding: 10px 16px;
                background-color: #0078D4;
                color: white;
                text-decoration: none;
                border-radius: 5px;
            }
            a:hover { background-color: #005a9e; }
        </style>
    </head>
    <body>
        <h1>Welcome to Page 1</h1>
        <p>This is the first page.</p>
        <p><a href='https://example.com'>Go to Page 2 (Example.com)</a></p>
        <p><a href='https://example.org'>Go to Page 3 (Example.org)</a></p>
    </body>
    </html>"
		};
	}
	private void AddTestCookie_Clicked(object sender, EventArgs e)
	{
		_viewModel.AddTestCookies();
	}
	private void ClearCookies_Clicked(object sender, EventArgs e)
	{
		_viewModel.ClearCookiesForCurrentSource();
	}
	private void TestDocumentTitle_Clicked(object sender, EventArgs e)
	{
		_viewModel.Source = new HtmlWebViewSource
		{
			Html = "<html><head><title>WebView Test Page</title></head><body><h1>Page with Title</h1><p>This page has a title that can be retrieved via JavaScript.</p></body></html>"
		};
	}
	private void LoadPage1_Clicked(object sender, EventArgs e)
	{
		_viewModel.Source = new HtmlWebViewSource
		{
			Html = @"<!DOCTYPE html>
        <html>
        <head>
            <title>Navigation Test - Page 1</title>
            <meta charset='utf-8'>
        </head>
        <body>
            <h1>Navigation Test - Page 1</h1>
            <p>This is the first page for navigation testing.</p>
            <a href='#' onclick='loadPage2()'>Go to Page 2</a>
            <script>
                function loadPage2() {
                    document.body.innerHTML = `
                        <h1>Navigation Test - Page 2</h1>
                        <p>This is the second page content rendered dynamically.</p>
                        <button onclick='loadPage1()'>Go Back</button>
                    `;
                    // Update title when content changes
                    document.title = 'Navigation Test - Page 2 (Dynamic)';
                }
                function loadPage1() {
                    document.body.innerHTML = `
                        <h1>Navigation Test - Page 1</h1>
                        <p>This is the first page for navigation testing.</p>
                        <a href='#' onclick='loadPage2()'>Go to Page 2</a>
                    `;
                    // Update title when content changes
                    document.title = 'Navigation Test - Page 1';
                }
                
                // Helper function for JavaScript evaluation
                window.testEvaluation = function() {
                    return 'JavaScript working on navigation page!';
                };
            </script>
        </body>
        </html>",
		};
	}
	private void LoadPage2_Clicked(object sender, EventArgs e)
	{
		_viewModel.Source = new HtmlWebViewSource
		{
			Html = @"<!DOCTYPE html>
        <html>
        <head>
            <title>Navigation Test - Page 2</title>
            <meta charset='utf-8'>
        </head>
        <body>
            <h1>Navigation Test - Page 2</h1>
            <p>This is the second page for navigation testing.</p>
            <button onclick='history.back()'>Go Back</button>
            <script>
                // Helper function for JavaScript evaluation
                window.testEvaluation = function() {
                    return 'JavaScript working on Page 2!';
                };
            </script>
        </body>
        </html>",
		};
	}
	private void IsVisibleRadio_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		if (!(sender is RadioButton rb) || !rb.IsChecked)
			return;
		_viewModel.IsVisible = rb.Content?.ToString() == "True";
	}
	private void ShadowRadio_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		if (e.Value && BindingContext is WebViewViewModel vm)
		{
			var rb = sender as RadioButton;
			if (rb?.Content?.ToString() == "True")
			{
				vm.Shadow = new Shadow { Brush = Brush.Black, Offset = new Point(5, 5), Radius = 5, Opacity = 0.5f };
			}
			else if (rb?.Content?.ToString() == "False")
			{
				vm.Shadow = null!;
			}
		}
	}
}
