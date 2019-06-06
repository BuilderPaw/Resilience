<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="ASPNetSpell" Namespace="ASPNetSpell" TagPrefix="ASPNetSpell" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="Scripts/jsHumanBody.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript">
        function ToAttachedFiles(sender, args) {
            $('html, body').animate({
                scrollTop: $("#divAttachedFiles").offset().top
            }, 1000);
        }

        function ToLinkedReports(sender, args) {
            $('html, body').animate({
                scrollTop: $("#divLinkedReports").offset().top
            }, 1000);
        }

        function ToPendingActions(sender, args) {
            $('html, body').animate({
                scrollTop: $("#divPendingActions").offset().top
            }, 1000);
        }

        function ToCommentSection(sender, args) {
            $('html, body').animate({
                scrollTop: $("#divComment").offset().top
            }, 1000);
        }
    </script>

    <div id="body" runat="server" class="body">
        
    </div>
</asp:Content>
