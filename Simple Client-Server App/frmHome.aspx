<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmHome.aspx.vb" Inherits="Simple_Client_Server_App.frmHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
			<p id="header"></p>
            <script>
				$(document).ready(function () {
					var timeForLoadContent = 60;
					var counter = 0
					var X_RANDOM = '';

					fetch_data(timeForLoadContent);

					function makeid(length) {
						X_RANDOM= '';
						var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
						var charactersLength = characters.length;
						for (var i = 0; i < length; i++) {
							X_RANDOM += characters.charAt(Math.floor(Math.random() * charactersLength));
						}

						counter = counter + 1;

						console.log(X_RANDOM);
						console.log(counter);



					}

					function fetch_data(timeForLoadContent) {

						makeid(8);

						if (timeForLoadContent > 0) {
							var ms = timeForLoadContent * 1000;
							//console.log($('#hal').val());
							setTimeout(function () {
								fetch_data(timeForLoadContent);
							}, ms);

						}

						var datas = {};
						datas.X_RANDOM = X_RANDOM;
						datas.counter = counter;

						$.ajax({
							type: "POST",
							dataType: "json",
							url: '<%= Page.ResolveUrl("~/webServices.asmx/HelloWorld")%>',
							data: JSON.stringify(datas),
							contentType: "application/json; charset=utf-8",
							//beforeSend: function () {
							//	// Show image container
							//	$("#loader").show();
							//},
							success: function (jsonData) {
								var resp = JSON.parse(jsonData.d);

								console.log(resp[0]);
								var dataHTML = '<h4 style="background-color:red">// Header</h4>' +
									'<span id = "lblRandom"> "X-RANDOM": ' + resp[0].xRandom + '</span>' +
									'<h4 style="background-color:red">// Body </h4>' +
									'<span id = "lblCounter" > { "counter": ' + resp[0].counter + ')</span>'

								$("#header").append(dataHTML);
							}

							
						});

						

					};
				});

				

				//setTimeout(makeid(5), 1000);
			</script>
        </div>
    </form>
</body>
</html>
