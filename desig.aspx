﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="desig.aspx.cs" Inherits="DesignationPro.desig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="DepartmentName" DataValueField="DepartmentId"></asp:DropDownList>
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbtesterConnectionString %>" SelectCommand="SELECT [DepartmentId], [DepartmentName] FROM [Department]"></asp:SqlDataSource>
         <p>
            <asp:Button ID="Button1" runat="server"  Text="Button" OnClick="Button1_Click1" />
        </p>
        <div>
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="DesignationId" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AutoGenerateDeleteButton="True" OnRowDeleting="GridView1_RowDeleting" AutoGenerateColumns="False" >
               <Columns>  
                <asp:TemplateField>  
                    <ItemTemplate>  
                        <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" />  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" runat="server" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CommandName="Cancel"/>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Designation Id">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_ID" runat="server" Text='<%#Eval("DesignationId") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Designation Name">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Name" runat="server" Text='<%#Eval("DesignationName") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Name" runat="server" Text='<%#Eval("DesignationName") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="City">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_Dname" runat="server" Text='<%#Eval("DepartmentName") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_Dname" runat="server" Text='<%#Eval("DepartmentName") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>  
            </Columns>  
            <HeaderStyle BackColor="#663300" ForeColor="#ffffff"/>  
            <RowStyle BackColor="#e7ceb6"/>  
  
            </asp:GridView>
        </div>
    </form>
</body>
</html>
