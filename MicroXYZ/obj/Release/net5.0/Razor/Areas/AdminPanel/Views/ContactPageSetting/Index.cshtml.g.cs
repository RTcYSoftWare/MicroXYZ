#pragma checksum "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74c93543a6921776d332219dc51afeaa227f0b61"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MicroXYZ.Pages.ContactPageSetting.Areas_AdminPanel_Views_ContactPageSetting_Index), @"mvc.1.0.view", @"/Areas/AdminPanel/Views/ContactPageSetting/Index.cshtml")]
namespace MicroXYZ.Pages.ContactPageSetting
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\_ViewImports.cshtml"
using MicroXYZ;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\_ViewImports.cshtml"
using MicroXYZ.Areas.AdminPanel.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\_ViewImports.cshtml"
using MicroXYZ.Database;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74c93543a6921776d332219dc51afeaa227f0b61", @"/Areas/AdminPanel/Views/ContactPageSetting/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a250e23efef0fab074d1a86638558182cc0fa9bd", @"/Areas/AdminPanel/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_AdminPanel_Views_ContactPageSetting_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ContactPageSetting>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
  
    ViewData["Title"] = "ContactPageSettings";
    Layout = "~/Pages/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"vh-100\">\r\n    <div class=\"col-12\">\r\n        <div class=\"bg-light rounded h-100 p-4\">\r\n            <div class=\"mb-4 d-flex flex-lg-row justify-content-between align-items-center\">\r\n                <h6>ContactPageSetting ");
#nullable restore
#line 11 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
                                  Write(Model.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Adet Bulunmaktadır.</h6>\r\n");
#nullable restore
#line 12 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
                 if (ViewBag.IsActive)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a href=\"/admin/contact-page-setting-edit\" type=\"button\" class=\"btn btn-outline-success\"><i class=\"fa fa-plus me-2\"></i>Yeni Ekle</a>\r\n");
#nullable restore
#line 15 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n\r\n");
#nullable restore
#line 18 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
             if (Model.Any())
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <table class=""table"">
                    <thead>
                        <tr>
                            <th scope=""col"">Title</th>
                            <th scope=""col"">Description</th>
                            <th scope=""col"">Phone</th>
                            <th scope=""col"">Created At</th>
                            <th scope=""col"">Durumu</th>
                            <th scope=""col"">Actions</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 32 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
                         foreach (var contactPageSetting in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 35 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
                               Write(contactPageSetting.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 36 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
                                Write(contactPageSetting.Description != null ? contactPageSetting.Description.Length > 25 ? contactPageSetting.Description.Substring(0,25) + "..." : contactPageSetting.Description : null);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 37 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
                               Write(contactPageSetting.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 38 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
                               Write(contactPageSetting.CreatedAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <p");
            BeginWriteAttribute("class", " class=\"", 1890, "\"", 1980, 3);
#nullable restore
#line 40 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
WriteAttributeValue("", 1898, contactPageSetting.IsActive ? "bg-success" : "bg-danger", 1898, 59, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1957, "table-is-active-baget", 1958, 22, true);
            WriteAttributeValue(" ", 1979, "", 1980, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        ");
#nullable restore
#line 41 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
                                    Write(contactPageSetting.IsActive ? "Aktif" : "Silindi");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </p>\r\n                                </td>\r\n                                <td>\r\n");
#nullable restore
#line 45 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
                                     if (ViewBag.IsActive)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a");
            BeginWriteAttribute("href", " href=\"", 2338, "\"", 2400, 2);
            WriteAttributeValue("", 2345, "/admin/contact-page-setting-edit/", 2345, 33, true);
#nullable restore
#line 47 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
WriteAttributeValue("", 2378, contactPageSetting.Id, 2378, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"m-0 btn btn-sm btn-sm-square btn-outline-warning\"><i class=\"fa fa-pen\"></i></a>\r\n");
#nullable restore
#line 48 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 50 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
                                     if (contactPageSetting.IsActive)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <button");
            BeginWriteAttribute("data", " data=\"", 2688, "\"", 2717, 1);
#nullable restore
#line 52 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
WriteAttributeValue("", 2695, contactPageSetting.Id, 2695, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-isActive=\"");
#nullable restore
#line 52 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
                                                                                        Write(contactPageSetting.IsActive);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" type=\"button\" class=\"contactPageSettingDeleteOrRestoreDeleteButton m-0 btn btn-sm btn-sm-square btn-outline-danger\"><i class=\"fa fa-trash\"></i></button>\r\n");
#nullable restore
#line 53 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <button");
            BeginWriteAttribute("data", " data=\"", 3085, "\"", 3114, 1);
#nullable restore
#line 56 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
WriteAttributeValue("", 3092, contactPageSetting.Id, 3092, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"button\" class=\"contactPageSettingDeleteOrRestoreDeleteButton m-0 btn btn-sm btn-sm-square btn-outline-info\"><i class=\"fa fa-recycle\"></i></button>\r\n");
#nullable restore
#line 57 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 60 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n");
            WriteLiteral(@"                <div class=""mb-4 d-flex flex-lg-row justify-content-between align-items-center"">
                    <h6>
                        Not: Ana sayfanızda gözükmesini istediğiniz bigilerin aktif olduğundan emin olunuz. Birden fazla aktif olması halinde
                        sıralamada ilk aktif olan ana sayfanızda gözükür.
                    </h6>
                </div>
");
#nullable restore
#line 70 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
            }

            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"mb-4 d-flex flex-lg-row justify-content-between align-items-center\">\r\n                    <h6>Kayıtlı Veri Bulunamadı !</h6>\r\n                </div>\r\n");
#nullable restore
#line 77 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\ContactPageSetting\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script>
        $("".nav-link"").removeClass(""active"");

        $(""#contactPageNavItem"").addClass(""active"");
        $(""#contactPageNavItem"").addClass(""show"");
        $("".contact-page-nav-item-menu"").addClass(""show"");

        $("".contactPageSettingDeleteOrRestoreDeleteButton"").click(function() {
            var contactPageSettingId = $(this).attr(""data"");
            var contactPageSettingIsActive = $(this).attr(""data-isActive"");

            console.log(contactPageSettingId);

            swal({
                title: contactPageSettingIsActive ? ""Silmek İstediğinize Emin Misiniz ?"" : ""Silinmiş Ögeyi Geri Almak İstediğinze Emin Misiniz ?"",
                text: contactPageSettingIsActive ? ""Bu işlemi silerseniz ana sayfanızda gözükmez!"" : ""Silinmiş ögeyi geri alırsanız ana sayfanızda gözükecektir !"",
                icon: ""warning"",
                buttons: [""İptal"", contactPageSettingIsActive ? ""Sil"" : ""Geri Al""],
                dangerMode: true,
            })
               ");
                WriteLiteral(@" .then((willDelete) => {
                    if (willDelete) {

                        $.ajax({
                            url: ""/admin/contact-page-setting-delete"",
                            type: ""POST"",
                            data: { id: contactPageSettingId, isActive: !contactPageSettingIsActive },
                            success: function(result) {
                                console.log(result);
                                if (result != null) {
                                    if (result.code == 20) {
                                        swal(""Silindi ! Bu bilgiler artık anasayfanızda gözükmeyecek !"", {
                                            icon: ""success"",
                                        }).then((value) => {
                                            location.reload();
                                        });
                                    }
                                    if (result.code == 22) {
                                  ");
                WriteLiteral(@"      swal(""Silme İşlemi Geri Alındı! Bu bilgiler artık ansayfanızda gözükecek !"", {
                                            icon: ""success"",
                                        }).then((value) => {
                                            location.reload();
                                        });
                                    }
                                    if (result.code == 9998) {
                                        swal(""Erişim Reddedildi !"", {
                                            icon: ""error"",
                                        });
                                    }
                                    if (result.code == 21) {
                                        swal(""Silinecek Eleman Bulunamadı !"", {
                                            icon: ""error"",
                                        });
                                    }
                                }
                            }
                        });
     ");
                WriteLiteral("               } else {\r\n                        swal(contactPageSettingIsActive ? \"Silme işlemi iptal edildi!\" : \"Geri alma iptal edildi!\");\r\n                    }\r\n                });\r\n        });\r\n\r\n    </script>\r\n");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ContactPageSetting>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
