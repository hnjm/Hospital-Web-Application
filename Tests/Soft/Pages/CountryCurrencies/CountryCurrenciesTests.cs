﻿using System.Threading.Tasks;
using EMEHospitalWebApp.Data.Party;
using EMEHospitalWebApp.Domain.Party;
using EMEHospitalWebApp.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EMEHospitalWebApp.Tests.Soft.Pages.CountryCurrencies {
    [TestClass] public class CountryCurrenciesTests : PagesTests<ICountryCurrencyRepo, CountryCurrency, CountryCurrencyData, CountryCurrencyView> {
        [TestInitialize] public void Init() => Init(x => new CountryCurrency(x));
        private async Task CheckIfContains(string url) {
            var html = await getHtmlPage(url);
            isNotNull(html);
            isNotNull(d);
            isNotNull(d.Id);
            isNotNull(d.CountryId);
            isNotNull(d.CurrencyId);
            isNotNull(d.Name);
            isNotNull(d.Code);
            isNotNull(d.Description);
            if (displayNameList is null) return;
            foreach (var name in displayNameList) isTrue(html.Contains(name));
            if (!url.Contains("Create") && !url.Contains("Index")) {
                isTrue(html.Contains(d.Id));
                //isTrue(html.Contains(d.CountryId)); TODO
                //isTrue(html.Contains(d.CurrencyId)); TODO
                isTrue(html.Contains(d.Name));
                isTrue(html.Contains(d.Code));
                isTrue(html.Contains(d.Description));
            }
        }
        [TestMethod] public async Task IndexTest() => await CheckIfContains("/CountryCurrencies?handler=Index");
        [TestMethod] public async Task CreateTest() => await CheckIfContains($"/CountryCurrencies/Create?handler=Create&id={id}&order=&idx=0&filter=");
        [TestMethod] public async Task DetailsTest() => await CheckIfContains($"/CountryCurrencies/Details?handler=Details&id={id}&order=&idx=0&filter=");
        [TestMethod] public async Task EditTest() => await CheckIfContains($"/CountryCurrencies/Edit?handler=Edit&id={id}&order=&idx=0&filter=");
        [TestMethod] public async Task DeleteTest() => await CheckIfContains($"/CountryCurrencies/Delete?handler=Delete&id={id}&order=&idx=0&filter=");
    }
}
