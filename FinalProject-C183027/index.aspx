<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FinalProject_C183027.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DCBMS-C183027</title>
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400;500;600;700&display=swap');
*, *::after, *::before {
    margin: 0;
    padding: 0;
    outline: 0;
    box-sizing: border-box;
}

html {
    font-size: 10px;
}

body {
    font-family: 'Poppins', sans-serif;
}

.container {
    width: 90%;
    min-height:780px;
    margin: 0 auto;
}

.container-wraper {
    margin-top: 5rem;
}
.home-main {
    width:100%;
    padding: 2rem;
    margin-right: 2rem;
    border-radius: 3rem;
    box-shadow: -1px 4px 14px #8f8888c7, -1px -2px 14px #8f8888e7;
}
.home-head-heading {
    font-size: 4rem;
    color: #707070;
    margin-top: 7rem;
    margin-bottom: 1rem;
    text-align: center;
}
.header-nav {
    padding: 20px;
    padding-left: 340px;
    margin-bottom: 100px;
}

.dropbtn {
    width: 160px;
    text-decoration: none;
    color: #fff;
    background: linear-gradient(to right, #FB924A, #FD4E30);
    padding: 1rem 3rem;
    font-size: 1.4rem;
    font-weight: bold;
    border: none;
    border-radius: 3.2rem;
    transition: .2s all ease-in-out;
}
.dropbtn:hover {
        background: linear-gradient(to right, #FD4E30,#FB924A);
        transition: .7s all ease;
}

.dropdown {
    position: relative;
    display: inline-block;
}

.dropdown-content {
    display: none;
    text-align: center;
    border-radius: 1rem;
    position: absolute;
    background-color:#fff;
    width: 160px;
    box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
    z-index: 1;
}

.dropdown-content a {
        color:black;
        padding: 12px 16px;
        text-decoration: none;
        display: block;
}

.dropdown-content a:hover {
    color:white;
    background-color: black;
}

.dropdown:hover .dropdown-content {
        display: block;
}

.dropdown:hover .dropbtn {
        background-color: #3e8e41;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <section class="container-wraper">
                <div class="home-main">
                <h2 class="home-head-heading">Diagnostic Center Bill Management System</h2>
                    <div class="header-nav">
                        <div class="dropdown">
                        <button class="dropbtn">Setup</button>
                        <div class="dropdown-content">
                            <a runat="server" href="~/view/testTypeSetup.aspx">Test Type</a>
                            <a runat="server" href="~/view/testSetup.aspx">Test</a>
                        </div>
                    </div>
                    <div class="dropdown">
                        <button class="dropbtn">Test Request</button>
                        <div class="dropdown-content">
                             <a runat="server" href="~/view/testRequestEntry.aspx">Entry</a>
                             <a runat="server" href="~/view/payment.aspx">Payment</a>
                        </div>
                    </div>
                    <div class="dropdown">
                        <button class="dropbtn">Report</button>

                        <div class="dropdown-content">
                            <a runat="server" href="~/view/testWiseReport.aspx">Test Wise</a>
                            <a runat="server" href="~/view/typeWiseReport.aspx">Type Wise</a>
                            <a runat="server" href="~/view/unpaidBillReport.aspx">Unpaid Bill</a>
                        </div>
                   </div>
                    </div>
               </div>
            </section>
         </div>
         <div class="container home">
            <footer>
                <p style="text-align:center;">&copy; <%: DateTime.Now.Year %> -Develop By Md Saifur Rahman</p>
            </footer>
         </div>
    </form>
</body>
</html>
