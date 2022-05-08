using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EMEHospitalWebApp.Aids;
using EMEHospitalWebApp.Data;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain;
using EMEHospitalWebApp.Facade;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EMEHospitalWebApp.Tests.Soft {
    public class PagesTests<TRepo, TObj, TData, TView> : HostTests
        where TRepo : class, IRepo<TObj>
        where TObj : UniqueEntity<TData>, new()
        where TData : UniqueData, new()
        where TView : UniqueView, new()
    {
        protected TData? d;
        protected CurrencyData? d2;
        protected TView? v;
        protected string id;
        protected List<string>? displayNameList;
        protected Dictionary<string, string>? genderDictionary;
        protected virtual void Init(Func<TData, TObj> toObj) {
            id = GetRandom.String();
            d = addRandomItems<TRepo, TObj, TData>(out _, toObj, id);
            v = new TView();
            getDisplayNames();
            getGenderDisplayNames();
        }
        private void getDisplayNames() {
            var properties = v?.GetType().GetProperties();
            displayNameList = new List<string>();
            if (properties is null) return;
            foreach (var p in properties) {
                var n = p.CustomAttributes.First().ToString();
                if (n.Contains('\"')) displayNameList.Add(n.Split('\"')[1]);
            }
        }
        private void getGenderDisplayNames() {
            var genderList = Enum.GetValues<IsoGender>()?.Select(x 
                => new SelectListItem(x.Description(), x.ToString())) ?? new List<SelectListItem>().ToList();
            genderDictionary = new Dictionary<string, string>();
            foreach (var name in genderList) genderDictionary.Add(name.Value, name.Text);
        }
        protected async Task<string> getHtmlPage(string url, HttpClient? client = null) {
            client ??= clientProduction;
            var page = await client.GetAsync(url);
            var html = await page.Content.ReadAsStringAsync();
            return html;
        }
    }
}
