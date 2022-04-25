using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;

namespace Mario
{
	class Program
	{
		static void Main(string[] args)
		{
			var ourWindow = new NativeWindowSettings()
			{
				Size = new Vector2i(900, 900),
				Title = "Proyek Grafkom"
			};

			using (var window = new Window(GameWindowSettings.Default, ourWindow))
			{
				window.Run();
			}
		}
	}
}
