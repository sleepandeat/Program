<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style media="screen" type="text/css">
        .boxout
        {
            height: 160px;
            width: 320px;
            padding: 8px;
            border: 1px solid #B5C7DE; 
            /*
		    margin-top的值等于-(height/2+padding+border的宽度)
		    margin-left的绝对值等于-(width/2+padding+border的宽度)
	        */
            margin-top: -100px;
            margin-left: -169px;
            position: absolute;
            left: 50%;
            top: 50%;
            background: #EFF3FB;  display: table;
        }
        .boxin
        {
            width: 100%;
            height: 100%;
            overflow: auto;
            display: table-cell;
            vertical-align: middle;
            text-align: center;
          
            color: #0066FF;
            font: normal normal normal 22px 微软雅黑;</style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="boxout">
        <div class="boxin">
            加载中，请稍候...
        </div>
    </div>
    </form>
</body>
</html>
