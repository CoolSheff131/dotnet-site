using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
	internal class Material : Page
	{
		public int DirectoryId { get; set; }//Внешний ключ
		public Directory Directory { get; set; }//Навигационное свойство
	}
}
