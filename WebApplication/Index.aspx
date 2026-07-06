<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Galaxy Realmart Pvt Ltd</title>

    <meta name="description" content="Galaxy Real Mart Pvt Ltd, scheme for LIG and EWS" />
    <meta name="author" content="okler.net">

    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1.0, shrink-to-fit=no">

    <!-- Web Fonts  -->
    <link id="googleFonts" href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700,800%7CShadows+Into+Light%7CPlayfair+Display:400&amp;display=swap" rel="stylesheet" type="text/css">

    <!-- Vendor CSS -->
    <link rel="stylesheet" href="EdenVENDOR/bootstrap/Css/bootstrap.min.css">
    <link rel="stylesheet" href="EdenVENDOR/fontawesome-free/css/all.min.css">
    <link rel="stylesheet" href="EdenVENDOR/animate/animate.compat.css">
    <link rel="stylesheet" href="EdenVENDOR/simple-line-icons/css/simple-line-icons.min.css">
    <link rel="stylesheet" href="EdenVENDOR/owl.carousel/assets/owl.carousel.min.css">
    <link rel="stylesheet" href="EdenVENDOR/owl.carousel/assets/owl.theme.default.min.css">
    <link rel="stylesheet" href="EdenVENDOR/magnific-popup/magnific-popup.min.css">
    <!-- Revolution Slider Addon - Typewriter -->
    <link rel="stylesheet" type="text/css" href="EdenVENDOR/rs-plugin/revolution-addons/typewriter/css/typewriter.css" />

    <!-- Theme CSS -->
    <link rel="stylesheet" href="EdenCSS/theme.css">
    <link rel="stylesheet" href="EdenCSS/theme-elements.css">
    <link rel="stylesheet" href="EdenCSS/theme-blog.css">
    <link rel="stylesheet" href="EdenCSS/theme-shop.css">

    <!-- Skin CSS -->
    <link id="skinCSS" rel="stylesheet" href="EdenCSS/skins/skin-corporate-14.css">

    <!-- Theme Custom CSS -->
    <link rel="stylesheet" href="EdenCSS/custom.css">


    <style>
        .header-body {
            background: white !important;
            background-color: white !important;
        }

        #header .header-nav a,
        #header .header-nav li a,
        #header .nav-item a {
            color: black !important;
        }

        #header a[href^="tel"] {
            color: black !important;
        }

        #header .header-nav a:hover {
            color: #333 !important;
        }

        #mainNav {
            display: flex;
            align-items: center;
            gap: 15px;
        }

        .apply-btn {
            padding: 6px 20px;
            font-size: 14px;
            background-color: gold !important;
        }

        html #header.header-transparent .header-body:not(.header-border-bottom) {
            top: 0px !important;
        }


        html {
            scroll-behavior: smooth;
        }


        h2 {
            line-height: 33px !important;
        }

        @media (min-width: 800px) {
            .mar {
                margin-top: -35px;
            }
        }

        .mar {
            font-size: 16px;
            color: white;
        }
    </style>
    <script>
        function next(step) {
            const inputs = document.querySelectorAll(`#step${step} [required]`);
            for (let input of inputs) {
                if (!input.checkValidity()) {
                    input.reportValidity();
                    return;
                }
            }
            document.getElementById(`step${step}`).style.display = 'none';
            document.getElementById(`step${step + 1}`).style.display = 'block';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="body">
            <header id="header" class="header-transparent header-semi-transparent" data-plugin-options="{'stickyEnabled': true, 'stickyEnableOnBoxed': true, 'stickyEnableOnMobile': false, 'stickyChangeLogo': false, 'stickyStartAt': 53, 'stickySetTop': '-53px'}">
                <div class="header-body border-top-0 bg-dark box-shadow-none" style="top: 0px !important">

                    <div class="header-container header-container-height-sm container container-xl-custom">
                        <div class="header-row">
                            <div class="header-column">
                                <div class="header-row">
                                    <div class="header-logo">
                                        <a href="index.aspx">
                                            <img src="Images/Eden-Garden-logo.png" style="width: 180px; height: auto;">
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="header-column justify-content-end">
                                <div class="header-row">
                                    <div class="header-nav header-nav-links header-nav-dropdowns-dark header-nav-light-text order-2 order-lg-1">
                                        <div class="header-nav-main header-nav-main-mobile-dark header-nav-main-square header-nav-main-dropdown-no-borders header-nav-main-effect-2 header-nav-main-sub-effect-1">
                                            <nav class="collapse">
                                                <ul class="nav nav-pills d-flex align-items-center gap-3" id="mainNav">
                                                    <li class="nav-item nav-item-borders py-2">
                                                        <a href="tel:7849825107" class="text-color-hover-light text-5">
                                                            <i class="fa fa-phone text-color-primary" aria-hidden="true" style="top: 0;"></i>7849825107 <span style="font-size: 12px">&nbsp; (10 AM - 5 PM)</span>
                                                        </a>

                                                    </li>

                                                    <li>
                                                        <a id="Apply" runat="server" href="Apply.aspx" target="_blank" class=" font-weight-bold text-5 py-2">Apply <i class="fas fa-arrow-right ms-2"></i></a>
                                                    </li>
                                                    <li style="text-align: center">
                                                        <a href="FormList.aspx" class=" font-weight-bold text-5 py-2">Final List<i class="fas fa-arrow-right ms-2"></i></a>
                                                        <p class="mar" style="color: var(--dark);">Status of Application in Final List<i class="fas fa-arrow-up ms-2"></i></p>
                                                    </li>
                                                    <%--<li>
                                                        <a href="AllotmentList.aspx" class=" font-weight-bold text-5 py-2">Final Lottery Allotment<i class="fas fa-arrow-down ms-2"></i></a>
                                                    </li>--%>
                                                    <li>
                                                        <a href="ReceiptList.aspx" class=" font-weight-bold text-5 py-2">Get Receipt/ Form<i class="fas fa-arrow-down ms-2"></i></a>
                                                    </li>








                                                    <%--<li>
                                                        <a  href="javascript:void(0)" class=" font-weight-bold text-5 py-2">Print Praman Patra</a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:void(0)" class=" font-weight-bold text-5 py-2">Scheme Booklet</a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:void(0)" class=" font-weight-bold text-5 py-2">Booking is closed now, please do not deposit any amount.</a>
                                                    </li>--%>
                                                </ul>

                                            </nav>
                                        </div>
                                        <%--<button class="btn header-btn-collapse-nav" data-bs-toggle="collapse" data-bs-target=".header-nav-main nav">
                                            <i class="fas fa-bars"></i>
                                        </button>--%>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </header>

            <div role="main" class="main">

                <section class="section overlay overlay-show overlay-op-8 border-0 m-0 p-0" style="background-image: url(Images/Home-BG-Image.jpg); background-size: cover; background-position: center; height: 100vh;">
                    <div class="container container-xl-custom pt-5 h-100">
                        <div class="row align-items-center pt-5 h-100">
                            <div class="col" style="padding-top: 200px;">
                                <%-- <h1 class="word-rotator letters type type-clean-light text-color-light font-weight-extra-bold text-12 line-height-2 mb-3 appear-animation" data-appear-animation="fadeIn" data-appear-animation-delay="300">
                                    <span>We are the best</span><br>
                                    <span class="word-rotator-words waiting">
                                        <b class="is-visible">EWS & LIG Housing </b>
                                        <b>That Feels Like Home.</b>
                                        <b>That Feels Like Home.</b>
                                        <b>That Feels Like Home.</b>
                                    </span>
                                </h1>--%>

                                <%--<p style="color:white; font-size:20px;">
                                    Welcome to The Galaxy Realmart Pvt Ltd
                                </p>--%>
                                <h1 style="color: white;">Welcome to The Galaxy Realmart Pvt Ltd
                                    <%--<p style="color: white; font-size: 20px;">
                                        class="text-4-5 text-color-light font-weight-light opacity-9 mb-4" data-plugin-animated-letters data-plugin-options="{'startDelay': 1500, 'minWindowWidth': 0, 'animationSpeed': 50}"
                                         - Those who have submitted their forms, please submit your DD and other related documents at registered office address before 20 April 2026 5:00 PM
                                    </p>
                                    <p style="color: white; font-size: 20px;">
                                        - जिन लोगों ने अपने फॉर्म जमा कर दिए हैं, कृपया अपने डिमांड ड्राफ्ट (DD) और अन्य संबंधित दस्तावेज़ 20 अप्रैल 2026 को शाम 5:00 बजे से पहले पंजीकृत कार्यालय के पते पर जमा करें।
                                    </p>--%>


                                    <%--<p style="color: white; font-size: 20px; font-family: monospace">
                                        - आज दिनांक 29-04-2026 को आयोजित की जाने वाली लॉटरी प्रक्रिया के दौरान कुछ आवेदकों द्वारा व्यवधान उत्पन्न किए जाने के कारण लॉटरी संपादित नहीं की जा सकी। अतः अगली तिथि निर्धारित होते ही इसकी सूचना वेबसाइट के माध्यम से प्रदान कर दी जाएगी। 
                                    </p>--%>
                                    <p style="color: white; font-size: 20px; font-family: monospace">
                                        - पुनः ऑनलाइन लाटरी दिनांक 7 जुलाई 2026 को दोपहर 2 बजे विकासकर्ता के पंजीकृत कार्यालय पर आयोजित की जावेगी| कृपया अपना मूल (Original) आधार कार्ड लेके आये| लाटरी स्थल पर प्रवेश सिर्फ आधार कार्ड से दिया जायेगा और जिन्होंने फॉर्म भरा है सिर्फ उनको ही प्रवेश दिया जायेगा| अन्य व्यक्तियों का प्रवेश वर्जित हैं| 
                                    </p>
                                </h1>
                                <a id="Apply1" runat="server" href="Apply.aspx" target="_blank" class="btn btn-primary btn-modern font-weight-bold text-3 py-3 btn-px-5 mt-2 appear-animation" data-appear-animation="fadeInUpShorter" data-appear-animation-delay="2200" data-appear-animation-duration="1.2s" data-plugin-options="{'minWindowWidth': 0}">APPLY<i class="fas fa-arrow-right ms-2"></i></a>
                            </div>
                        </div>
                    </div>
                </section>


                <section id="headlo" class="section section-height-3 section-parallax bg-color-light border-0 m-0" data-plugin-parallax="" data-plugin-options="{'speed': 1.5, 'parallaxHeight': '100%', 'offset': 70}" data-image-src="img/parallax/parallax-corporate-14-2.jpg">
                    <div class="container container-xl-custom">
                        <div class="row align-items-center">
                            <div class="col-md-6 col-lg-5 col-xl-6 text-center pe-5 mb-5 mb-md-0 appear-animation" data-appear-animation="fadeInLeftShorter" data-appear-animation-delay="400">
                                <h3>Category Wise Plot</h3>

                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" Font-Size="11pt"
                                    DataKeyNames="CategoryName" AllowPaging="true" CssClass="grid"
                                    Width="100%" PageSize="50" CellPadding="10">
                                    <Columns>
                                        <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                                        <asp:BoundField DataField="EWSCount" HeaderText="EWS" />

                                        <asp:BoundField DataField="LIGCount" HeaderText="LIG" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Records Found...
                                    </EmptyDataTemplate>
                                    <AlternatingRowStyle BackColor="#f9f9f9" />
                                    <RowStyle BackColor="#DACDCD" />

                                    <RowStyle ForeColor="Black" />
                                    <HeaderStyle BackColor="Black" />
                                    <HeaderStyle ForeColor="White" />
                                    <PagerStyle CssClass="GridPager" />
                                </asp:GridView>
                            </div>
                            <div class="col-md-6 col-lg-7 col-xl-6 appear-animation" data-appear-animation="fadeInLeftShorter" data-appear-animation-delay="200">
                                <span class="font-weight-bold text-color-dark opacity-8 text-4">Easy & Transparent Registration Charges</span>
                                <h2 class="font-weight-bold text-5 mb-4">At Galaxy Star City, we believe in clarity and affordability. Our one-time registration fees are minimal to ensure accessibility for all:</h2>
                                <ul class="list list-icons pb-2 mb-4">
                                    <li><i class="fas fa-caret-right top-6"></i><span class="text-4">LIG (Low-Income Group): ₹1000</span></li>
                                    <li><i class="fas fa-caret-right top-6"></i><span class="text-4">EWS (Economically Weaker Section): ₹500</span></li>
                                </ul>
                                <p>No hidden costs – just a simple step toward your dream home.</p>
                                <a id="Apply2" runat="server" href="Apply.aspx" class="btn btn-primary font-weight-semibold rounded-0 btn-px-5 py-3 text-2" target="_blank">APPLY</a>
                            </div>
                        </div>
                    </div>
                </section>


                <div id="aboutID" class="container container-xl-custom py-5 my-5">
                    <div class="row justify-content-center">
                        <div class="col-xl-9 text-center">
                            <h2 class="font-weight-bold text-11 appear-animation" data-appear-animation="fadeInUpShorter">A WORD ABOUT US</h2>
                            <p class="line-height-9 text-4 opacity-9 appear-animation" data-appear-animation="fadeInUpShorter" data-appear-animation-delay="200">The Galaxy Realmart Pvt Ltd is the flagship project of Galaxy Group. Spread across 100 acres, it is perhaps the biggest gated township of Rajasthan. Much more than just a township, it is the realization of our vision to bring the calm environs of the village close to the city. With luxurious farmhouses, villas and wide open spaces, this may just be the place you are looking to get away to.</p>
                            <p class="line-height-9 text-4 opacity-9 appear-animation" data-appear-animation="fadeInUpShorter" data-appear-animation-delay="200">We are proud to present the comforts of the city life nestled in extensive green expanse. We have already planted more than 10,000 trees/plants and this is just the beginning. It is a stone’s throw away from the city centre yet in a cocoon of its own.</p>
                            <p class="line-height-9 text-4 opacity-9 appear-animation" data-appear-animation="fadeInUpShorter" data-appear-animation-delay="200">There are endless comforts and pleasures to be explored and enjoyed in and around The Galaxy Realmart Pvt Ltd. Relax, unwind and celebrate with friends and family in style.</p>
                        </div>
                        <%-- <div class="col-xl-9 text-center py-5">
                            <h2 class="font-weight-bold text-11 appear-animation" data-appear-animation="fadeInUpShorter">Category Wise Alloted Plot List</h2>

                            <img src="assets/img/Allotment.jpeg" style="display: block; margin-left: auto; margin-right: auto" />
                        </div>--%>
                    </div>
                </div>
                <div class="container container-xl-custom py-5 my-5">
                    <div class="justify-content-center">
                        <div class="col-md-12 text-center">
                            <h1 class="appear-animation" data-appear-animation="fadeInUpShorter">पेपर प्रकाशन</h1>
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <img src="/assets/img/PressRelease.png" class="img-fluid" alt="" style="max-width: 600px; height: auto; display: block; margin: 0 auto;" />
                                </div>
                                <div class="col-md-6">
                                    <img src="/assets/img/RevisedPaper.jpeg" class="img-fluid" alt="" />
                                </div>
                                <div class="col-md-6">
                                    <img src="/assets/img/PressRelease6July26.jpeg" class="img-fluid" alt="" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!--<section class="section section-height-3 section-parallax bg-color-grey border-0 m-0 appear-animation" data-appear-animation="fadeIn" data-plugin-parallax data-plugin-options="{'speed': 1.5, 'parallaxHeight': '100%', 'offset': 70}" data-image-src="img/parallax/parallax-corporate-14-3.jpg">
                    <div class="container container-xl-custom">
                        <div class="row justify-content-between align-items-center">
                            <div class="col-md-7 order-2 order-md-1 appear-animation" data-appear-animation="fadeInRightShorter" data-appear-animation-delay="200">
                                <span class="font-weight-bold text-color-dark opacity-8 text-4">MODERN</span>
                                <h2 class="font-weight-bold text-9 mb-4">Mobile Advanced Apps</h2>
                                <ul class="list list-icons pb-2 mb-4">
                                    <li><i class="fas fa-caret-right top-6"></i><span class="text-4">Lorem ipsum dolor sit amet, consectetur adipiscing elit.</span></li>
                                    <li><i class="fas fa-caret-right top-6"></i><span class="text-4">Ipsum dolor sit amet, consectetur adipiscing elit.</span></li>
                                    <li><i class="fas fa-caret-right top-6"></i><span class="text-4">Dolor sit amet, lorem ipsum consectetur adipiscing elit.</span></li>
                                </ul>
                                <a href="#" class="btn btn-primary font-weight-semibold rounded-0 btn-px-5 py-3 text-2">LEARN MORE</a>
                            </div>
                            <div class="col-md-4 text-center text-md-start order-1 order-md-2 mb-5 mb-md-0 me-lg-5 appear-animation" data-appear-animation="fadeInRightShorter" data-appear-animation-delay="400">
                                <img src="img/smartphone-corporate-14-3.png" class="img-fluid" alt="" />
                            </div>
                        </div>
                    </div>
                </section>

                <section class="section section-height-5 section-background overlay overlay-show overlay-op-9 border-0 m-0 appear-animation" data-appear-animation="fadeIn" style="background-image: url(img/bg-corporate-14-1.jpg); background-size: cover; background-position: center;">
                    <div class="container container-xl-custom my-5">
                        <div class="row justify-content-center">
                            <div class="col-md-10 col-xl-9 text-center">
                                <h2 class="font-weight-bold text-color-light text-11 mb-4 appear-animation" data-appear-animation="fadeInUpShorter" data-appear-animation-delay="200">Get in touch and learn how we can help</h2>
                                <p class="font-weight-light text-color-light line-height-9 text-4 opacity-7 mb-5 appear-animation" data-appear-animation="fadeInUpShorter" data-appear-animation-delay="400">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras volutpat id sapien ac varius. Fusce hendrerit ligula a consectetur ullamcorper. Vestibulum varius pharetra lorem.</p>
                                <a href="#" class="d-inline-flex align-items-center btn btn-primary font-weight-semibold px-5 btn-py-3 text-3 rounded appear-animation" data-appear-animation="fadeInUpShorter" data-appear-animation-delay="550">GET STARTED NOW <i class="fa fa-arrow-right ms-2 ps-1 text-5"></i></a>
                            </div>
                        </div>
                    </div>
                </section> -->
            </div>

            <footer id="footer" class="mt-0">
                <div class="container container-xl-custom my-4">
                    <div class="row py-5">
                        <div class="col-lg-4 mb-5 mb-lg-0 text-center text-lg-start pt-3">
                            <h5 class="text-5 text-transform-none font-weight-semibold text-color-light mb-4">GALAXY REALMART</h5>
                            <p class="text-4 mb-3">
                                GALAXY REALMART proudly presents affordable housing solutions under the
                                <br>
                                LIG (Low-Income Group) and EWS (Economically Weaker Section) schemes. 
                               
                            </p>
                            <a id="Apply3" runat="server" href="Apply.aspx" target="_blank" class="d-inline-flex align-items-center btn btn-primary font-weight-semibold px-5 btn-py-3 text-3 rounded mt-2">APPLY</a>
                        </div>
                        <div class="col-lg-4 mb-4 mb-md-0 text-center text-lg-start pt-3">
                            <h5 class="text-5 text-transform-none font-weight-semibold text-color-light mb-4">Pages</h5>
                            <ul class="list list-icons list-icons-sm d-inline-flex flex-column">
                                <li class="text-4 mb-2"><i class="fas fa-angle-right"></i><a href="#headlo" class="link-hover-style-1 ms-1">Scheme</a></li>
                                <li class="text-4 mb-2"><i class="fas fa-angle-right"></i><a href="#aboutID" class="link-hover-style-1 ms-1">About Us</a></li>
                                <li class="text-4 mb-2"><i class="fas fa-angle-right"></i><a href="Terms-and-Conditions.aspx" class="link-hover-style-1 ms-1">Terms and Conditions</a></li>
                                <li class="text-4 mb-2"><i class="fas fa-angle-right"></i><a href="Privacy-Policy.aspx" class="link-hover-style-1 ms-1">Privacy Policy</a></li>
                                <li class="text-4 mb-2"><i class="fas fa-angle-right"></i><a href="javascript:void(0)" class="link-hover-style-1 ms-1">Print Praman Patra</a></li>
                                <li class="text-4 mb-2"><i class="fas fa-angle-right"></i><a href="Documents/EWS_Book_Galaxy_Enclave.pdf" target="_blank" class="link-hover-style-1 ms-1">Scheme Booklet <i class="fas fa-file-pdf ms-1" style="color: #ffffff;"></i></a></li>
                            </ul>
                        </div>
                        <div class="col-lg-4 mb-4 mb-lg-0 text-center text-lg-start pt-3">
                            <h5 class="text-5 text-transform-none font-weight-semibold text-color-light mb-4">Contact Us</h5>
                            <p class="text-4 mb-2"><span class="text-color-light">Address:</span> S.P. 05, 03 Floor, Rico Industrial Area, Mansarovar, Jaipur – 302020</p>
                            <p class="text-4 mb-2"><span class="text-color-light">Phone:</span> <a href="tel:7849825107">7849825107</a></p>
                            <%--<p class="text-4 mb-2"><span class="text-color-light">Email:</span> <a href="javascript:void(0)">ambrishtiwari@gmail.com</a></p>--%>
                        </div>

                    </div>
                </div>
                <div class="container container-xl-custom">
                    <div class="footer-copyright footer-copyright-style-2">
                        <div class="py-2">
                            <div class="row py-4">
                                <div class="col d-flex align-items-center justify-content-center mb-4 mb-lg-0">
                                    <p>
                                        © Copyright 2025. All Rights Reserved. 
                                        <!--Developed By | <a href="https://www.tweakhere.com/" target="_blank">TweakHere Technocrat Pvt Ltd</a>-->
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </footer>
        </div>

        <!-- Vendor -->
        <script data-cfasync="false" src="../../../cdn-cgi/scripts/5c5dd728/cloudflare-static/email-decode.min.js">
        </script>
        <script src="EdenVENDOR/plugins/js/plugins.min.js"></script>

        <script src="EdenJS/theme.js"></script>
        <script type="text/javascript" src="EdenVENDOR/rs-plugin/revolution-addons/typewriter/js/revolution.addon.typewriter.min.js"></script>

        <script src="EdenJS/theme.init.js"></script>
    </form>
</body>
</html>
