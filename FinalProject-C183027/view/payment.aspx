<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="FinalProject_C183027.view.payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DCBMS-C183027</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
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
            margin: 0 auto;
        }
        .home{
             width:80%;
             margin:0 auto;
             margin-bottom:2rem;
             border-radius: 3rem;
             box-shadow: -1px 4px 14px #8f8888c7, -1px -2px 14px #8f8888e7;
        }
        
        .head-mr{
            padding-top:5rem;
        }
        a{
            margin: 0 30rem;
            font-size: 1.6rem;
            font-weight: 300;
            text-decoration:none;
            height:40px;
            width:185px;
            color:black;
        }
        h2{
            color: #707070;
            padding-top: 7rem;
            padding-bottom: 1rem;
            text-align:center;
            font-size:3rem;
        }
        .text-input{
            padding-top:2rem;
            text-align:center;
            width:100%;
        }
        .Label-cl{
            font-size: 1.6rem;
            font-weight: 300;
            color: #575757;
            margin-right:2rem;
        }
        .input{
              height: 40px;
              width: 300px;
              font-size: max(16px, 1em);
              font-family: inherit;
              padding: 0.25em 0.5em;
              background-color: #fff;
              border: 2px solid black;
              border-radius: 4px;
        }
        .btnn{
            height:40px;
            width:185px;
            font-size: 1.6rem;
            font-weight: 300;
            color: #575757;
            
        }
        .mb{
            margin-bottom: 2rem;
        }
        .color{
            margin-left: 70px;
            color:red;
        }
        .home-footer{
            margin:4rem;
            padding:2rem;
        } 
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="home">
           <div class="head-mr">
               <a class="text-center " runat="server" href="~/index.aspx">Home Page</a>
           </div>
           <h2>Payment Page</h2>
           <div class="text-input">
                  <asp:Label CssClass="Label-cl" for="billNoInput" ID="billNoLabel" runat="server" Text="Bill No"></asp:Label>
                  <asp:TextBox id="billNoInput" class="input" runat="server" placeholder="Enter Bill Number" ></asp:TextBox>
           </div>
            <div class="text-input">
                 <asp:Label class="Label-cl color" ID="fdff" Text="OR"  runat="server"></asp:Label>
            </div>
           <div class="text-input">
                <asp:Label for="mobileNoInput" class="Label-cl" ID="Label1" runat="server" Text="Mobile Number"></asp:Label>
                <asp:TextBox ID="mobileNoInput" class="input" runat="server" placeholder="Enter Mobile Number" ></asp:TextBox>
           </div>
            <div class="text-input">
                 <asp:Button ID="searchButton" class="text-center btnn" runat="server" Text="SEARCH" OnClick="searchButton_Click" />
            </div>
            <div class="text-input">
                 <asp:Label class="Label-cl color" ID="outputLabel"  runat="server"></asp:Label>
            </div>
            <div class="text-input">
                <asp:Label for="amountInput" class="Label-cl" ID="Label2" runat="server" Text="Amount"></asp:Label>
                <asp:TextBox ID="amountInput" class="input" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="text-input">
                <asp:Label for="dueDateInput" class="Label-cl" ID="Label3" runat="server" Text="Due Date"></asp:Label>
                <asp:TextBox ID="dueDateInput" Type="date" class="input" runat="server" ></asp:TextBox>
            </div>
            <div class="text-input">
                 <asp:Button ID="payButton" class="text-center btnn mb" runat="server" Text="PAY AMOUNT" OnClick="payButton_Click" />
            </div>
        </div>

        <div class="home-footer home">
            <footer>
                <p class="Label-cl" style="text-align:center;">&copy; <%: DateTime.Now.Year %> -Develop By Md Saifur Rahman</p>
            </footer>
        </div>
    </form>
</body>
</html>
