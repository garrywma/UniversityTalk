using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using UCL2.Model;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using AppServiceHelpers.Forms;
using AppServiceHelpers.Abstractions;
using System.Runtime.CompilerServices;

namespace UCL2.ViewModel
{
	public class LecturesViewModel : BaseAzureViewModel<Lecture>
	{
		public LecturesViewModel(IEasyMobileServiceClient client) : base(client) { }
	}
}