namespace PresentationLayer.Models
{
	public class DirectoryViewModel : PageViewModel
	{
		public DataLayer.Entities.Directory Directory { get; set; }
		public List<MaterialViewModel> Materials { get; set; }
	}

	public class DirectoryEditModel : PageEditModel
	{
	}
}
