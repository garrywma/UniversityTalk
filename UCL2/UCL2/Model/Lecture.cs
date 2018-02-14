using System;
using AppServiceHelpers.Models;

namespace UCL2.Model
{
	public class Lecture : EntityData
	{
		public string starts { get; set; }
		public string ends { get; set; }
		public string title { get; set; }
		public string venue { get; set; }
		public string address { get; set; }
		public string presenter { get; set; }
		public string image { get; set; }
		public string biography { get; set; }
	}
}
