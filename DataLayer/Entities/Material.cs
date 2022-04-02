namespace DataLayer.Entities
{
	public class Material : Page
	{
		public int DirectoryId { get; set; }//Внешний ключ
		public Directory Directory { get; set; }//Навигационное свойство
	}
}
