using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
	internal class Directory : Page
	{
		public List<Material> Materials { get; set; }
	}
}
