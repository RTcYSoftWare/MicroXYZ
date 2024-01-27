#pragma checksum "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8de0ccfb4b04751156126ef92a52dd05c24b66f5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MicroXYZ.Pages.Admin.Areas_AdminPanel_Views_Admin_Index), @"mvc.1.0.view", @"/Areas/AdminPanel/Views/Admin/Index.cshtml")]
namespace MicroXYZ.Pages.Admin
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8de0ccfb4b04751156126ef92a52dd05c24b66f5", @"/Areas/AdminPanel/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a250e23efef0fab074d1a86638558182cc0fa9bd", @"/Areas/AdminPanel/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_AdminPanel_Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Admin>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
  
    ViewData["Title"] = "Admins";
    Layout = "~/Pages/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"vh-100\">\r\n    <div class=\"col-12\">\r\n        <div class=\"bg-light rounded h-100 p-4\">\r\n            <div class=\"mb-4 d-flex flex-lg-row justify-content-between align-items-center\">\r\n                <h6>Admin ");
#nullable restore
#line 11 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
                     Write(Model.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Adet Bulunmaktadır.</h6>\r\n");
#nullable restore
#line 12 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
                 if (ViewBag.IsActive)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a href=\"/admin/admin-edit\" type=\"button\" class=\"btn btn-outline-success\"><i class=\"fa fa-plus me-2\"></i>Yeni Ekle</a>\r\n");
#nullable restore
#line 15 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n\r\n");
#nullable restore
#line 18 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
             if (Model.Any())
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <table class=""table"">
                    <thead>
                        <tr>
                            <th scope=""col"">Name Surname</th>
                            <th scope=""col"">Email</th>
                            <th scope=""col"">Phone</th>
                            <th scope=""col"">Created At</th>
                            <th scope=""col"">Durumu</th>
                            <th scope=""col"">Actions</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 32 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
                         foreach (var admin in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 35 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
                               Write(admin.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 35 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
                                           Write(admin.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 36 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
                               Write(admin.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 37 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
                               Write(admin.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 38 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
                               Write(admin.CreatedAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <p");
            BeginWriteAttribute("class", " class=\"", 1628, "\"", 1705, 3);
#nullable restore
#line 40 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
WriteAttributeValue("", 1636, admin.IsActive ? "bg-success" : "bg-danger", 1636, 46, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1682, "table-is-active-baget", 1683, 22, true);
            WriteAttributeValue(" ", 1704, "", 1705, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        ");
#nullable restore
#line 41 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
                                    Write(admin.IsActive ? "Aktif" : "Silindi");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </p>\r\n                                </td>\r\n                                <td>\r\n");
#nullable restore
#line 45 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
                                     if (ViewBag.IsActive)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a");
            BeginWriteAttribute("href", " href=\"", 2050, "\"", 2084, 2);
            WriteAttributeValue("", 2057, "/admin/admin-edit/", 2057, 18, true);
#nullable restore
#line 47 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
WriteAttributeValue("", 2075, admin.Id, 2075, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"m-0 btn btn-sm btn-sm-square btn-outline-warning\"><i class=\"fa fa-pen\"></i></a>\r\n");
#nullable restore
#line 48 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 50 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
                                     if (admin.IsActive)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <button");
            BeginWriteAttribute("data", " data=\"", 2359, "\"", 2375, 1);
#nullable restore
#line 52 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
WriteAttributeValue("", 2366, admin.Id, 2366, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-isActive=\"");
#nullable restore
#line 52 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
                                                                           Write(admin.IsActive);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" type=\"button\" class=\"adminDeleteOrRestoreDeleteButton m-0 btn btn-sm btn-sm-square btn-outline-danger\"><i class=\"fa fa-trash\"></i></button>\r\n");
#nullable restore
#line 53 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <button");
            BeginWriteAttribute("data", " data=\"", 2717, "\"", 2733, 1);
#nullable restore
#line 56 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
WriteAttributeValue("", 2724, admin.Id, 2724, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"button\" class=\"adminDeleteOrRestoreDeleteButton m-0 btn btn-sm btn-sm-square btn-outline-info\"><i class=\"fa fa-recycle\"></i></button>\r\n");
#nullable restore
#line 57 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 60 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n");
#nullable restore
#line 63 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
            }

            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"mb-4 d-flex flex-lg-row justify-content-between align-items-center\">\r\n                    <h6>Kayıtlı Veri Bulunamadı !</h6>\r\n                </div>\r\n");
#nullable restore
#line 70 "C:\Users\turan\source\repos\MicroXYZ\MicroXYZ\Areas\AdminPanel\Views\Admin\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script>
        $("".nav-link"").removeClass(""active"");

        $(""#adminsNavItem"").addClass(""active"");
        //$(""#productNavItem"").addClass(""show"");
        //$("".product-nav-item-menu"").addClass(""show"");

        $("".adminDeleteOrRestoreDeleteButton"").click(function() {
            var adminId = $(this).attr(""data"");
            var adminIsActive = $(this).attr(""data-isActive"");

            console.log(adminId);

            swal({
                title: adminIsActive ? ""Silmek İstediğinize Emin Misiniz ?"" : ""Silinmiş Ögeyi Geri Almak İstediğinze Emin Misiniz ?"",
                text: adminIsActive ? ""Bu işlemi silerseniz ana sayfanızda gözükmez!"" : ""Silinmiş ögeyi geri alırsanız ana sayfanızda gözükecektir !"",
                icon: ""warning"",
                buttons: [""İptal"", adminIsActive ? ""Sil"" : ""Geri Al""],
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {

                        $.ajax({
");
                WriteLiteral(@"                            url: ""/admin/admin-delete"",
                            type: ""POST"",
                            data: { id: adminId, isActive: !adminIsActive },
                            success: function(result) {
                                console.log(result);
                                if (result != null) {
                                    if (result.code == 40) {
                                        swal(""Silindi ! Bu bilgiler artık anasayfanızda gözükmeyecek !"", {
                                            icon: ""success"",
                                        }).then((value) => {
                                            location.reload();
                                        });
                                    }
                                    if (result.code == 42) {
                                        swal(""Silme İşlemi Geri Alındı! Bu bilgiler artık ansayfanızda gözükecek !"", {
                                            icon: ""succe");
                WriteLiteral(@"ss"",
                                        }).then((value) => {
                                            location.reload();
                                        });
                                    }
                                    if (result.code == 9998) {
                                        swal(""Erişim Reddedildi !"", {
                                            icon: ""error"",
                                        });
                                    }
                                    if (result.code == 41) {
                                        swal(""Silinecek Eleman Bulunamadı !"", {
                                            icon: ""error"",
                                        });
                                    }
                                }
                            }
                        });
                    } else {
                        swal(adminIsActive ? ""Silme işlemi iptal edildi!"" : ""Geri alma iptal edildi!"");
            ");
                WriteLiteral("        }\r\n                });\r\n        });\r\n\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Admin>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
