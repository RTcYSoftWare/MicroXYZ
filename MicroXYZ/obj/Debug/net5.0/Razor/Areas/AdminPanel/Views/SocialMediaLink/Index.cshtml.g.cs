#pragma checksum "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "87d00be99ba2ef3b074f18d2f131f59e3c9e67308b511cb8132bcbe67076b445"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MicroXYZ.Pages.SocialMediaLink.Areas_AdminPanel_Views_SocialMediaLink_Index), @"mvc.1.0.view", @"/Areas/AdminPanel/Views/SocialMediaLink/Index.cshtml")]
namespace MicroXYZ.Pages.SocialMediaLink
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"87d00be99ba2ef3b074f18d2f131f59e3c9e67308b511cb8132bcbe67076b445", @"/Areas/AdminPanel/Views/SocialMediaLink/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"59898f179ce82ec626e39df6478acd2eb55c7e859cafef9e388310a93170e3b9", @"/Areas/AdminPanel/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_AdminPanel_Views_SocialMediaLink_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SocialMediaLink>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Pages/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"vh-100\">\r\n    <div class=\"col-12\">\r\n        <div class=\"bg-light rounded h-100 p-4\">\r\n            <div class=\"mb-4 d-flex flex-lg-row justify-content-between align-items-center\">\r\n                <h6>SocialMediaLink ");
#nullable restore
#line 11 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
                               Write(Model.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Adet Bulunmaktadır.</h6>\r\n");
#nullable restore
#line 12 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
                 if (ViewBag.IsActive)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a href=\"/admin/socail-media-link-edit\" type=\"button\" class=\"btn btn-outline-success\"><i class=\"fa fa-plus me-2\"></i>Yeni Ekle</a>\r\n");
#nullable restore
#line 15 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n\r\n");
#nullable restore
#line 18 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
             if (Model.Any())
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <table class=""table"">
                    <thead>
                        <tr>
                            <th scope=""col"">Title</th>
                            <th scope=""col"">Url</th>
                            <th scope=""col"">Created At</th>
                            <th scope=""col"">Durumu</th>
                            <th scope=""col"">Actions</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 31 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
                         foreach (var socialMediaLink in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 34 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
                               Write(socialMediaLink.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 35 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
                               Write(socialMediaLink.Url);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 36 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
                               Write(socialMediaLink.CreatedAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <p");
            BeginWriteAttribute("class", " class=\"", 1563, "\"", 1650, 3);
#nullable restore
#line 38 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
WriteAttributeValue("", 1571, socialMediaLink.IsActive ? "bg-success" : "bg-danger", 1571, 56, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1627, "table-is-active-baget", 1628, 22, true);
            WriteAttributeValue(" ", 1649, "", 1650, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        ");
#nullable restore
#line 39 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
                                    Write(socialMediaLink.IsActive ? "Aktif" : "Silindi");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </p>\r\n                                </td>\r\n                                <td>\r\n");
#nullable restore
#line 43 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
                                     if (ViewBag.IsActive)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a");
            BeginWriteAttribute("href", " href=\"", 2005, "\"", 2061, 2);
            WriteAttributeValue("", 2012, "/admin/socail-media-link-edit/", 2012, 30, true);
#nullable restore
#line 45 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
WriteAttributeValue("", 2042, socialMediaLink.Id, 2042, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"m-0 btn btn-sm btn-sm-square btn-outline-warning\"><i class=\"fa fa-pen\"></i></a>\r\n");
#nullable restore
#line 46 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 48 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
                                     if (socialMediaLink.IsActive)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <button");
            BeginWriteAttribute("data", " data=\"", 2346, "\"", 2372, 1);
#nullable restore
#line 50 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
WriteAttributeValue("", 2353, socialMediaLink.Id, 2353, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-isActive=\"");
#nullable restore
#line 50 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
                                                                                     Write(socialMediaLink.IsActive);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" type=\"button\" class=\"socialMediaLinkDeleteOrRestoreDeleteButton m-0 btn btn-sm btn-sm-square btn-outline-danger\"><i class=\"fa fa-trash\"></i></button>\r\n");
#nullable restore
#line 51 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <button");
            BeginWriteAttribute("data", " data=\"", 2734, "\"", 2760, 1);
#nullable restore
#line 54 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
WriteAttributeValue("", 2741, socialMediaLink.Id, 2741, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"button\" class=\"socialMediaLinkDeleteOrRestoreDeleteButton m-0 btn btn-sm btn-sm-square btn-outline-info\"><i class=\"fa fa-recycle\"></i></button>\r\n");
#nullable restore
#line 55 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 58 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n");
            WriteLiteral(@"                <div class=""mb-4 d-flex flex-lg-row justify-content-between align-items-center"">
                    <h6>
                        Not: Ana sayfanızda gözükmesini istediğiniz bigilerin aktif olduğundan emin olunuz.
                    </h6>
                </div>
");
#nullable restore
#line 67 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
            }

            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"mb-4 d-flex flex-lg-row justify-content-between align-items-center\">\r\n                    <h6>Kayıtlı Veri Bulunamadı !</h6>\r\n                </div>\r\n");
#nullable restore
#line 74 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\SocialMediaLink\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script>
        $("".nav-link"").removeClass(""active"");

        $(""#socialMediaLinksNavItem"").addClass(""active"");
        //$(""#processesNavItem"").addClass(""show"");
        //$("".processes-nav-item-menu"").addClass(""show"")

        $("".socialMediaLinkDeleteOrRestoreDeleteButton"").click(function() {
            var socialMediaLinkId = $(this).attr(""data"");
            var socialMediaLinkIsActive = $(this).attr(""data-isActive"");

            console.log(socialMediaLinkId);

            swal({
                title: socialMediaLinkIsActive ? ""Silmek İstediğinize Emin Misiniz ?"" : ""Silinmiş Ögeyi Geri Almak İstediğinze Emin Misiniz ?"",
                text: socialMediaLinkIsActive ? ""Bu işlemi silerseniz ana sayfanızda gözükmez!"" : ""Silinmiş ögeyi geri alırsanız ana sayfanızda gözükecektir !"",
                icon: ""warning"",
                buttons: [""İptal"", socialMediaLinkIsActive ? ""Sil"" : ""Geri Al""],
                dangerMode: true,
            })
                .then((willDelete");
                WriteLiteral(@") => {
                    if (willDelete) {

                        $.ajax({
                            url: ""/admin/social-media-link-delete"",
                            type: ""POST"",
                            data: { id: socialMediaLinkId, isActive: !socialMediaLinkIsActive },
                            success: function(result) {
                                console.log(result);
                                if (result != null) {
                                    if (result.code == 15) {
                                        swal(""Silindi ! Bu bilgiler artık anasayfanızda gözükmeyecek !"", {
                                            icon: ""success"",
                                        }).then((value) => {
                                            location.reload();
                                        });
                                    }
                                    if (result.code == 17) {
                                        swal(""Silme İşlemi Ge");
                WriteLiteral(@"ri Alındı! Bu bilgiler artık ansayfanızda gözükecek !"", {
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
                                    if (result.code == 16) {
                                        swal(""Silinecek Eleman Bulunamadı !"", {
                                            icon: ""error"",
                                        });
                                    }
                                }
                            }
                        });
                    } else {
  ");
                WriteLiteral("                      swal(socialMediaLinkIsActive ? \"Silme işlemi iptal edildi!\" : \"Geri alma iptal edildi!\");\r\n                    }\r\n                });\r\n        });\r\n\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SocialMediaLink>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591