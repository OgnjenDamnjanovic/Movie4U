#pragma checksum "E:\Napredne baze projekti\NeoGit\Neo4j\Pages\News.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dcce98c4c5e77fca9626f02cc7129fc8946ae9da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Neo4j.Pages.Pages_News), @"mvc.1.0.razor-page", @"/Pages/News.cshtml")]
namespace Neo4j.Pages
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
#line 1 "E:\Napredne baze projekti\NeoGit\Neo4j\Pages\_ViewImports.cshtml"
using Neo4j;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dcce98c4c5e77fca9626f02cc7129fc8946ae9da", @"/Pages/News.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07fbaa0100dfc7fde41963a5c38640a5ceb844b3", @"/Pages/_ViewImports.cshtml")]
    public class Pages_News : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dcce98c4c5e77fca9626f02cc7129fc8946ae9da2817", async() => {
                WriteLiteral(@"
<title>Movie4U | News</title>
<!-- for-mobile-apps -->
<meta name=""viewport"" content=""width=device-width, initial-scale=1"">
<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
<meta name=""keywords"" content=""One Movies Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyEricsson, Motorola web design"" />
<script type=""application/x-javascript""> addEventListener(""load"", function() { setTimeout(hideURLbar, 0); }, false);
		function hideURLbar(){ window.scrollTo(0,1); } </script>
<!-- //for-mobile-apps -->
<link href=""css/bootstrap.css"" rel=""stylesheet"" type=""text/css"" media=""all"" />
<link href=""css/style.css"" rel=""stylesheet"" type=""text/css"" media=""all"" />
<link rel=""stylesheet"" href=""css/faqstyle.css"" type=""text/css"" media=""all"" />
<link href=""css/single.css"" rel='stylesheet' type='text/css' />
<link rel=""stylesheet"" href=""css/contactstyle.css"" type=");
                WriteLiteral(@"""text/css"" media=""all"" />
<!-- news-css -->
<link rel=""stylesheet"" href=""news-css/news.css"" type=""text/css"" media=""all"" />
<!-- //news-css -->
<!-- list-css -->
<link rel=""stylesheet"" href=""list-css/list.css"" type=""text/css"" media=""all"" />
<!-- //list-css -->
<!-- font-awesome icons -->
<link rel=""stylesheet"" href=""css/font-awesome.min.css"" />
<!-- //font-awesome icons -->
<!-- js -->
<script type=""text/javascript"" src=""js/jquery-2.1.4.min.js""></script>
<!-- //js -->
<link href='//fonts.googleapis.com/css?family=Roboto+Condensed:400,700italic,700,400italic,300italic,300' rel='stylesheet' type='text/css'>
<!-- start-smoth-scrolling -->
<script type=""text/javascript"" src=""js/move-top.js""></script>
<script type=""text/javascript"" src=""js/easing.js""></script>
<script type=""text/javascript"">
	jQuery(document).ready(function($) {
		$("".scroll"").click(function(event){		
			event.preventDefault();
			$('html,body').animate({scrollTop:$(this.hash).offset().top},1000);
		});
	});
</script>
<!-- ");
                WriteLiteral("start-smoth-scrolling -->\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"


<!-- faq-banner -->
	<div class=""faq"">
			<div class=""container"">
				<div class=""agileinfo-news-top-grids"">
					<div class=""col-md-8 wthree-top-news-left"">


<h4>Latest news</h4><br><br>
						
							<div class=""bs-example bs-example-tabs""  role=""tabpanel"" data-example-id=""togglable-tabs"">
								
								<div id=""myTabContent"" class=""tab-content"">
									<div role=""tabpanel"" class=""tab-pane fade in active"" id=""home1"" aria-labelledby=""home1-tab"">
									<div class=""wthree-news-top-left"" id=""insert-here"">
											
");
#nullable restore
#line 64 "E:\Napredne baze projekti\NeoGit\Neo4j\Pages\News.cshtml"
                                     for (int i = 0; i < @Model.vestiByDate.Count; i++)
									{
										
										

#line default
#line hidden
#nullable disable
            WriteLiteral(@"											<div class=""col-md-6 w3-agileits-news-left"" style=""padding:7px;margin-bottom: 15px; height:fit-content; border-bottom: 2px dotted rgb(255,152,0);border-right: 2px dotted rgb(255,152,0);"">
												<div class=""col-sm-5 wthree-news-img"">
													<a");
            BeginWriteAttribute("href", " href=\"", 3054, "\"", 3100, 2);
            WriteAttributeValue("", 3061, "News-single?id=", 3061, 15, true);
#nullable restore
#line 70 "E:\Napredne baze projekti\NeoGit\Neo4j\Pages\News.cshtml"
WriteAttributeValue("", 3076, Model.vestiByDate[i].id, 3076, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><img style=\"width:150px; height: 100px;\"");
            BeginWriteAttribute("src", "src=", 3142, "", 3173, 1);
#nullable restore
#line 70 "E:\Napredne baze projekti\NeoGit\Neo4j\Pages\News.cshtml"
WriteAttributeValue("", 3146, Model.vestiByDate[i].slika, 3146, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /></a>\r\n\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"col-sm-7 wthree-news-info\">\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<h5><a");
            BeginWriteAttribute("href", " href=\"", 3274, "\"", 3320, 2);
            WriteAttributeValue("", 3281, "News-single?id=", 3281, 15, true);
#nullable restore
#line 73 "E:\Napredne baze projekti\NeoGit\Neo4j\Pages\News.cshtml"
WriteAttributeValue("", 3296, Model.vestiByDate[i].id, 3296, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 73 "E:\Napredne baze projekti\NeoGit\Neo4j\Pages\News.cshtml"
                                                                                                     Write(Model.vestiByDate[i].naslov);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h5>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<p style=\"word-wrap: break-word;font-size:12px;height:100px\">");
#nullable restore
#line 74 "E:\Napredne baze projekti\NeoGit\Neo4j\Pages\News.cshtml"
                                                                                                            Write(Model.vestiByDate[i].opis);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<ul>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<li><i class=\"fa fa-clock-o\" aria-hidden=\"true\"></i> ");
#nullable restore
#line 76 "E:\Napredne baze projekti\NeoGit\Neo4j\Pages\News.cshtml"
                                                                                                        Write(Model.vestiByDate[i].datumPostavljanja.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t\t<li><i class=\"fa fa-thumbs-o-up\" aria-hidden=\"true\"></i> ");
#nullable restore
#line 77 "E:\Napredne baze projekti\NeoGit\Neo4j\Pages\News.cshtml"
                                                                                                            Write(Model.vestiByDate[i].brojLajkova);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t</ul>\r\n\t\t\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"clearfix\"> </div>\r\n\t\t\t\t\t\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 82 "E:\Napredne baze projekti\NeoGit\Neo4j\Pages\News.cshtml"
											
									}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"  </div>
								
							</div>
						</div>
					</div>

					<div class=""clearfix""> </div>
				</div><div class=""col-md-4 wthree-news-right"">
						
						<!-- news-right-bottom -->
						<div class=""news-right-bottom"">
							<div class=""wthree-news-right-heading"">
								<h3>Top News</h3>
							</div>
							<div class=""news-right-bottom-bg"">
								<div class=""news-grids-bottom"" >

");
#nullable restore
#line 100 "E:\Napredne baze projekti\NeoGit\Neo4j\Pages\News.cshtml"
                                     foreach (var vest in Model.vestiMostLiked)
									{
										

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t<div class=\"top-news-grid\">\r\n\t\t\t\t\t\t\t\t\t\t<div class=\"top-news-grid-heading\">\r\n\t\t\t\t\t\t\t\t\t\t\t<a");
            BeginWriteAttribute("href", " href=\"", 4442, "\"", 4472, 2);
            WriteAttributeValue("", 4449, "News-single?id=", 4449, 15, true);
#nullable restore
#line 105 "E:\Napredne baze projekti\NeoGit\Neo4j\Pages\News.cshtml"
WriteAttributeValue("", 4464, vest.id, 4464, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 105 "E:\Napredne baze projekti\NeoGit\Neo4j\Pages\News.cshtml"
                                                                         Write(vest.naslov);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t\t<div class=\"w3ls-news-t-grid top-t-grid\">\r\n\t\t\t\t\t\t\t\t\t\t\t<ul>\r\n\t\t\t\t\t\t\t\t\t\t\t\t<li><a href=\"#\"><i class=\"fa fa-clock-o\"></i> ");
#nullable restore
#line 109 "E:\Napredne baze projekti\NeoGit\Neo4j\Pages\News.cshtml"
                                                                                         Write(vest.datumPostavljanja.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\r\n\t\t\t\t\t\t\t\t\t\t\t\t<li><a href=\"#\"><i class=\"fa fa-thumbs-o-up\"></i>");
#nullable restore
#line 111 "E:\Napredne baze projekti\NeoGit\Neo4j\Pages\News.cshtml"
                                                                                            Write(vest.brojLajkova);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n\t\t\t\t\t\t\t\t\t\t\t</ul>\r\n\t\t\t\t\t\t\t\t\t\t</div>\r\n\t\t\t\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 115 "E:\Napredne baze projekti\NeoGit\Neo4j\Pages\News.cshtml"
									}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"									
									
									
									
								</div>
							</div>
						</div>
						<!-- //news-right-bottom -->
					</div>
			</div>
	</div>
<!-- //faq-banner -->
<button style=""margin-left:45%""id=""load_more"">Load more</button> <br> <br><br> <br>
<script>
										
	document.querySelector(""#load_more"").onclick=()=>
				{
								

							$.ajax({
      						 method: ""GET"",
							    url: '?handler=LoadMore', 
							   beforeSend: function (xhr) {
           						 xhr.setRequestHeader(""XSRF-TOKEN"",
              					  $('input:hidden[name=""__RequestVerificationToken""]').val());},
      						 contentType: ""application/json; charset=utf-8"",
     				 		 dataType: ""json""
  							 }).done(function (data) {
      								if(data=="""")
									 document.querySelector(""#load_more"").style.display=""none"";
									  else
									  {		
										  	data.forEach((vest)=>
											  {
												  console.log(vest);
												  document.querySelector(""#insert-here"").i");
            WriteLiteral(@"nnerHTML+=
												  `<div class=\""col-md-6 w3-agileits-news-left"" style=\""padding:7px;margin-bottom: 15px; height:fit-content; border-bottom: 2px dotted rgb(255,152,0);border-right: 2px dotted rgb(255,152,0);\"">
												<div class=\""col-sm-5 wthree-news-img\"">
													<a href=\""News-single?id=${vest[""id""]}\""><img style=\""width:150px; height: 100px;\"" src=\""${vest[""slika""]}\""/></a>
												</div>
												<div class=""col-sm-7 wthree-news-info"">
													<h5><a href=""News-single?id=${vest[""id""]}"">${vest[""naslov""]}</a></h5>
													<p style=\""word-wrap: break-word; font-size:12px; height:100px;\"">${vest[""opis""]}</p>
													<ul>
														<li><i class=""fa fa-clock-o"" aria-hidden=""true""></i> ${getFormattedDate(new Date(vest[""datumPostavljanja""]))}</li>
														<li><i class=""fa fa-thumbs-o-up"" aria-hidden=""true""></i> ${vest[""brojLajkova""]}</li>
													</ul>
												</div>
												<div class=""clearfix""> </div>
												</div>`;	

								");
            WriteLiteral(@"
												


											  });
									  }
										
							   });

				}

				function getFormattedDate(date) {
												let year = date.getFullYear();
												let month = (1 + date.getMonth()).toString().padStart(2, '0');
												let day = date.getDate().toString().padStart(2, '0');
											console.log(date);
												return month + '/' + day + '/' + year;
														}

</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MyApp.Namespace.NewsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MyApp.Namespace.NewsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MyApp.Namespace.NewsModel>)PageContext?.ViewData;
        public MyApp.Namespace.NewsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
