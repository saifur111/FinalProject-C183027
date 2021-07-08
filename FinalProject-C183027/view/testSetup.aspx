<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="testSetup.aspx.cs" Inherits="FinalProject_C183027.view.testSetup" %>

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
        .home{
             width:80%;
             margin:2rem auto;
             padding:2rem;
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
        .color{
            margin-left: 70px;
            color:red;
        }
        .table{
            font-size: 1.6rem;
            margin-top:50px;
            border-radius: 4px;
            padding:0 50px;
            max-height:400px;
            overflow-y:auto;
        }
        .container-home{
            width: 80%;
            margin: 0 auto;
        }
        .home-footer{
            margin: 12.5rem;
            padding: 1rem;
            margin-top: 5rem;
        }
        .Label-cl-f{
            font-size: 1.6rem;
            font-weight: 300;
            color: #575757;
        }
        .home-footer p{
            margin-bottom:0;
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <div class="home">
           <div class="head-mr">
               <a class="text-center " runat="server" href="~/index.aspx">Home Page</a>
           </div>
           <h2 class="text-center">Test Setup</h2>
           <div class="text-input">
                <asp:Label for="textNameTextBox" class="Label-cl" ID="Label1" runat="server" Text="Test Name"></asp:Label>
                <asp:TextBox ID="textNameTextBox" class="input" runat="server" required="required"></asp:TextBox>
           </div>
           <div class="text-input">
                <asp:Label class="Label-cl" ID="Label2" runat="server" Text="Fee Amount"></asp:Label>
                <asp:TextBox ID="feeTexBox" class="input" runat="server" required="required"></asp:TextBox> &nbsp; &nbsp;BDT
           </div>
           <div class="text-input">
                <asp:Label class="Label-cl" ID="Label3" runat="server" Text="Test Type"></asp:Label>
                <asp:DropDownList class="input" ID="testTypeDropDownList" runat="server"></asp:DropDownList>
           </div>
           <div class="text-input">
                 <asp:Button ID="saveButton" class="text-center btnn" runat="server" Text="SAVE" OnClick="saveButton_Click"/>
            </div>
           <div class="text-input">
                 <asp:Label class="Label-cl color" ID="outputLabel"  runat="server"></asp:Label>
            </div>
            <div class="table">
                 <asp:GridView class="text-center" ID="testSetupGridView" AutoGenerateColumns="False" CssClass="gridView table table-striped table-dark table-wrapper-scroll-y my-custom-scrollbar table-striped mb-0 text-center" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="SN" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                                 <ItemTemplate>
                                     <%#Container.DataItemIndex+1 %>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Test Name" ItemStyle-Width="250px">
                                 <ItemTemplate>
                                       <asp:Label Text='<%#Eval("TestName") %>' runat="server"></asp:Label><%--test class variable--%>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Fee" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                                 <ItemTemplate>
                                 <asp:Label Text='<%#Eval("Fee") %>' runat="server"></asp:Label>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Test Type" ItemStyle-Width="100px">
                                 <ItemTemplate>
                                      <asp:Label Text='<%#Eval("TestType") %>' runat="server"></asp:Label>
                                 </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
       </div>
        <footer>
            <div class="container-home home-footer home">
                <p class="Label-cl-f" >&copy; <%: DateTime.Now.Year %> -Develop By Md Saifur Rahman</p>
            </div>
        </footer>
    </form>
</body>
</html>
