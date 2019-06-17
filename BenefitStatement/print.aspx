<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="print.aspx.cs" Inherits="BenefitStatement.print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <link href="print.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function GetEE(url) {
            alert('You have not selected an employee yet.\nYou will be redirected to the employee search ');
            window.open('/WEB_PROJECTS/EMPLOYEE_SEARCH/DEFAULT.ASPX?SkipCheck=YES&goto=/WEB_PROJECTS/BENEFITSTATEMENT/DEFAULT.ASPX?SkipCheck=YES', '_self');
        }

        function NoAccess(msg) {
            alert(msg);
            window.open('/web_projects/DemographicsPage/Default.aspx?SkipCheck=YES', '_self');
        }
    </script>

</head>
<body style="font-size: 12pt;background-color: white; padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px;
    padding-top: 0px">


    <form id="form1" runat="server">
        
        <%--<table border="0" cellpadding="0" cellspacing="0" style="width: 770px" 
            class="fontsmall">
            <tr>
                <td style="height: 19px; padding-left: 10px;" bgcolor="#f4ede1">
                <asp:Label ID="LblTemplateHeader2" runat="server"></asp:Label>
                </td>
            </tr>
        </table>--%>
        <div class="FullPage" style="float: left">
            <div class="FullPage" id="dvAll" runat="server" style="float: left; margin-left: 10px;">
                <div id="Div5" class="InputRowTitle" 
                    style="width: 650px; text-align: right; margin-top: 10px;">
                    <asp:HyperLink ID="hlPrint" runat="server" CssClass="FontSmall10" Font-Bold="True"
                        NavigateUrl="Javascript:window.print()" ToolTip="Print">Print</asp:HyperLink>
                    <asp:HyperLink ID="hlPrintIcon" runat="server" CssClass="FontSmall10" Font-Bold="True"
                        NavigateUrl="Javascript:window.print()" ImageUrl="~/Img/printer.png" ToolTip="Print">Print</asp:HyperLink>
                </div>
                <div class="DataPagePadding">
                    <div class="FullEnroolSectionShort">
                        <span style="font-family: Arial"><strong>Benefits Statement</strong></span></div>
                    <div class="FullEnroolSectio">
                        <div class="SubEnroolSectionlong">
                            <asp:Label ID="Label3" runat="server" CssClass="FontSmall" Font-Bold="True" Text="Master Account:"></asp:Label>&nbsp;</div>
                        <div class="SubEnroolSectio">
                            <asp:Label ID="lblMasterAccount" runat="server" CssClass="FontSmall"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="DataPagePadding">
                    <div class="FullEnroolSectionShort">
                        &nbsp;
                    </div>
                    <div class="FullEnroolSectio">
                        <div class="SubEnroolSectionlong">
                            <asp:Label ID="Label4" runat="server" CssClass="FontSmall" Font-Bold="True" Text="Account Number:"></asp:Label>&nbsp;</div>
                        <div class="SubEnroolSectio">
                            <asp:Label ID="lblAccountNumber" runat="server" CssClass="FontSmall"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="DataPagePadding">
                    <div class="FullEnroolSectionShort">
                        &nbsp;
                    </div>
                    <div class="FullEnroolSectio">
                        <div class="SubEnroolSectionlong">
                            <asp:Label ID="Label7" runat="server" CssClass="FontSmall" Font-Bold="True" Text="Account Name:"></asp:Label>&nbsp;</div>
                        <div class="SubEnroolSectio">
                            <asp:Label ID="lblAccountName" runat="server" CssClass="FontSmall"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="DataPagePadding">
                    <div class="FullEnroolSectionShort">
                        &nbsp;</div>
                    <div class="FullEnroolSectio">
                        <div class="SubEnroolSectionlong">
                            <asp:Label ID="Label5" runat="server" CssClass="FontSmall" Font-Bold="True" Text="Employee ID:"></asp:Label>
                        </div>
                        <div class="SubEnroolSectio">
                            <asp:Label ID="lblEmployeeID" runat="server" Text="Account Number" CssClass="FontSmall"></asp:Label>
                        </div>
                    </div>
                </div>

                <div class="DataPagePadding">
                    <div class="FullEnroolSectionShort">
                        <asp:Label ID="lblName1" runat="server" CssClass="FontSmall" Font-Bold="False"></asp:Label>
                    </div>
                    <div class="FullEnroolSectio">
                        <div class="SubEnroolSectionlong">
                            <asp:Label ID="Label12" runat="server" CssClass="FontSmall" Font-Bold="True" Text="Plan Year:"></asp:Label>
                        </div>
                        <div class="SubEnroolSectio">
                            <asp:Label ID="lblPlanYear" runat="server" Text="" CssClass="FontSmall"></asp:Label>
                        </div>
                    </div>
                </div>



                <div class="DataPagePadding">
                    <div class="FullEnroolSectionShort">
                        <asp:Label ID="lblName2" runat="server" CssClass="FontSmall"></asp:Label>
                    </div>
                    <div class="FullEnroolSectio">
                        <div class="SubEnroolSectionlong">
                            <asp:Label ID="Label6" runat="server" CssClass="FontSmall" Font-Bold="True" Text="Prepared On:"></asp:Label>
                        </div>
                        <div class="SubEnroolSectio">
                            <asp:Label ID="lblPreparedOn" runat="server" Text="Account Number" CssClass="FontSmall"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="DataPagePadding">
                    <div class="FullEnroolSectionShort">
                        <asp:Label ID="lblName3" runat="server" CssClass="FontSmall"></asp:Label>
                    </div>
                    <div class="FullEnroolSectio">
                        <div class="SubEnroolSectionlong">
                            <asp:Label ID="Label8" runat="server" CssClass="FontSmall" Font-Bold="True" Text="Customer Service Phone:"></asp:Label>
                        </div>
                        <div class="SubEnroolSectio">
                            <asp:Label ID="lblSupportPhone" runat="server" Text="1.877.303.7382" CssClass="FontSmall"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="DataPagePadding">
                    <div class="FullEnroolSectionShort">
                        <asp:Label ID="lblName4" runat="server" CssClass="FontSmall"></asp:Label>
                    </div>
                    <div class="FullEnroolSectio">
                        <div class="SubEnroolSectionlong">
                            <asp:Label ID="Label10" runat="server" CssClass="FontSmall" Font-Bold="True" Text="Customer Service Email:"></asp:Label>
                        </div>
                        <div class="SubEnroolSectio">
                            <asp:Label ID="lblServiceEmail" runat="server" Text="Service@RetaEnroll.org" CssClass="FontSmall"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="Datablank10" style="width: 564px;">
                    &nbsp;
                </div>
                <div id="dvTitle" class="InputRowTitle" style="width: 650px">
                    <asp:Label ID="lblInstuction" runat="server" CssClass="FontSmall">The following summarizes your group benefit plan enrollment for the "Plan Year" identified above. If you have any questions about this information, you may email or call us at the listed above. </asp:Label>
                </div>
                <div id="Div4" class="InputRowTitle" style="width: 650px">
                    <asp:Label ID="lblCost" runat="server" CssClass="FontSmall" ForeColor="Maroon">
      <b><u><span style="font-size:12.0pt;color:red"><br>****Your plan costs for medical/vision, and/or dental are not displayed below. Please refer to the "Plan Cost" document in the Reference Library.****</span></u> </b>
                    </asp:Label></div>
                <div class="Datablank10" style="height: 25px; width: 650px;">
                    &nbsp;
                </div>
                <div id="dvYourElectionTitle" class="InputRowTitle" style="width: 556px" runat="server">
                    <asp:Label ID="lblYourElection" runat="server" Text="Your Elections" CssClass="FontSmall10"
                        Font-Bold="True" ForeColor="Blue"></asp:Label>
                </div>
                <div id="dvYourElection" class="InputRowTitle" runat="server" 
                    style="width: 700px">
                    <asp:Label ID="Label9" runat="server" CssClass="FontSmall">
      Your monthly cost is based on a 12 month pay schedule.  It will be different for those paid on a 10 month pay schedule.
                    </asp:Label>
                </div>
                <div class="Datablank10" style="width: 554px;">
                &nbsp;
            </div>
                <div id="dvTax" class="NewDataColumn" runat="server" visible="false" 
                    style="width: 650px">
                    <div style="float: left; vertical-align: bottom; width: 650px; height: 27px;" 
                        class="dvYourElection">
                        <br />
                        <asp:Label ID="lblOption" runat="server" CssClass="FontSmall" Font-Bold="True">Payroll Deduction</asp:Label>&nbsp;
                        <asp:Label ID="lblPayRollDeduction" runat="server" CssClass="FontSmall"></asp:Label></div>
                    <div style="width: 554px" class="Datablank10">
                    </div>
                    <div style="float: left; width: 650px">
                        <asp:RadioButtonList ID="rblDeductionOption" runat="server" Width="93px" CssClass="FontSmall"
                            Visible="False">
                            <asp:ListItem Value="1">Pre-tax</asp:ListItem>
                            <asp:ListItem Value="0">Post-tax</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div style="float: left; width: 650px;">
                        &nbsp;</div>
                </div>
                <div class="InputRowTitle" style="width: 650px" id="Div6" runat="server">
                <asp:GridView ID="gvSummary" runat="server" AutoGenerateColumns="False" CssClass="FontSmall"
                        GridLines="None" Width="650px" OnRowCreated="gvSummary_RowCreated1" 
                        ShowFooter="True">
                        <Columns>
                            <asp:TemplateField HeaderText="Coverage Group" Visible="False">
                                <FooterStyle BackColor="#F4EDE1" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="long_description" HeaderText="Benefit Plan">
                                <FooterStyle BackColor="#F4EDE1" />
                                <HeaderStyle HorizontalAlign="Left" Width="210px" />
                                <ItemStyle Width="210px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BenefitLevel" HeaderText="Benefit Level">
                                <FooterStyle BackColor="#F4EDE1" Font-Bold="True" HorizontalAlign="Right" />
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle Width="85px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Core/Optional" DataField="BenefitType">
                                <HeaderStyle HorizontalAlign="Center" />
                                <FooterStyle BackColor="#F4EDE1" HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Cost">
                                <FooterStyle BackColor="#F4EDE1" />
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="effective_date" HeaderText="Effective Date">
                                <FooterStyle BackColor="#F4EDE1" />
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Last Change Date" HeaderText="Change Date">
                                <FooterStyle BackColor="#F4EDE1" />
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    
                </div>
                <div class="InputRowTitle" style="width: 690px;" id="dvExtra" runat="server">
                <iframe id='iExtra' runat="server" width="69px" height="300px" name="Extra" 
                    frameborder="0" />
            </div>
                <div class="InputRowTitle" style="width: 650px" id="dvSummary" runat="server">
                <asp:GridView ID="gvSummaryold" runat="server" AutoGenerateColumns="False" CssClass="FontSmall"
                        GridLines="None" Width="650px" OnRowCreated="gvSummary_RowCreated" 
                        ShowFooter="True">
                        <Columns>
                            <asp:TemplateField HeaderText="Coverage Group" Visible="False">
                                <FooterStyle BackColor="#F4EDE1" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="long_description" HeaderText="Benefit Plan">
                                <FooterStyle BackColor="#F4EDE1" />
                                <HeaderStyle HorizontalAlign="Left" Width="210px" />
                                <ItemStyle Width="210px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BenefitLevel" HeaderText="Benefit Level">
                                <FooterStyle BackColor="#F4EDE1" Font-Bold="True" HorizontalAlign="Right" />
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle Width="85px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Core/Optional" DataField="BenefitType">
                                <HeaderStyle HorizontalAlign="Center" />
                                <FooterStyle BackColor="#F4EDE1" HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PerPayCost" HeaderText="Your Per Pay Cost" 
                                Visible="False">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <FooterStyle BackColor="#F4EDE1" Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="er_premium_perpay" HeaderText="Trustor Monthly Cost "
                                Visible="False">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <FooterStyle BackColor="#F4EDE1" Font-Bold="True" HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MonthlyCost" HeaderText="Monthly Cost" Visible="False">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <FooterStyle BackColor="#F4EDE1" Font-Bold="True" HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="effective_date" HeaderText="effective Date">
                                <FooterStyle BackColor="#F4EDE1" />
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Last Change Date" HeaderText="Change Date">
                                <FooterStyle BackColor="#F4EDE1" />
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <%--<asp:GridView ID="gvSummary" runat="server" AutoGenerateColumns="False" CssClass="FontSmall"
                        GridLines="None" Width="650px" OnRowCreated="gvSummary_RowCreated" 
                        ShowFooter="True">
                        <Columns>
                            <asp:TemplateField HeaderText="Coverage Group" Visible="False">
                                <FooterStyle BackColor="#F4EDE1" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="long_description" HeaderText="Benefit Plan">
                                <FooterStyle BackColor="#F4EDE1" />
                                <ItemStyle Width="275px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BenefitLevel" HeaderText="Benefit Level">
                                <FooterStyle BackColor="#F4EDE1" Font-Bold="True" HorizontalAlign="Right" />
                                <ItemStyle Width="85px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Core/Optional" DataField="BenefitType">
                                <HeaderStyle HorizontalAlign="Center" />
                                <FooterStyle BackColor="#F4EDE1" HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Center" Width="130px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PerPayCost" HeaderText="Your Per Pay Cost" 
                                Visible="False">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <FooterStyle BackColor="#F4EDE1" Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="er_premium_perpay" HeaderText="Trustor Monthly Cost "
                                Visible="False">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <FooterStyle BackColor="#F4EDE1" Font-Bold="True" HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MonthlyCost" HeaderText="Monthly Cost" Visible="False">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <FooterStyle BackColor="#F4EDE1" Font-Bold="True" HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="effective_date" HeaderText="effective Date">
                                <FooterStyle BackColor="#F4EDE1" />
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Last Change Date" HeaderText="Change Date">
                                <FooterStyle BackColor="#F4EDE1" />
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>--%>
                </div>
                <div class="InputRowTitle" style="width: 650px" id="dvSpecisl" runat="server">
                    <asp:GridView ID="gvspecial" runat="server" AutoGenerateColumns="False" CssClass="FontSmall"
                        GridLines="None" Width="650px" ShowFooter="True">
                        <Columns>
                            <asp:BoundField DataField="Elected Benefit Options" HeaderText="Elected Benefit Options">
                                <ItemStyle Width="315px" />
                                <HeaderStyle HorizontalAlign="Left" Width="315px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Benefit Level" HeaderText="Benefit Level">
                                <ItemStyle Width="85px" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Last Change Date" DataField="Last Change Date">
                                <HeaderStyle HorizontalAlign="Center" Width="85px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Original Coverage Date" HeaderText="Original Coverage Date">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="85px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="End Date" HeaderText="End Date">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" Width="85px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Your Cost Biweekly" HeaderText="Your Cost Biweekly">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="Datablank10" style="width: 554px;">
                    &nbsp;
                </div>
                <div class="InputRowTitle" style="width: 556px" id="divPendingTitle" runat="server">
                    <asp:Label ID="Label1" runat="server" Text="Your Pending Elections" CssClass="FontSmall10"
                        Font-Bold="True" ForeColor="Blue"></asp:Label>
                    <br />
                    <asp:Label ID="lblNoPendingElection" runat="server" CssClass="FontSmall" Font-Bold="True"
                        ForeColor="Maroon" Text="You do not have any pending elections" Visible="False"></asp:Label></div>
                <div class="InputRowTitle" style="width: 556px" id="divPendingInstruction" runat="server">
                    <asp:Label ID="lblEOIPending" runat="server" Text="Pending elections indicate a request for coverage and will not be effective without administrative and/or insurance carrier approval. Approval of pending elections may change your total monthly cost of benefits."
                        CssClass="FontSmall"></asp:Label>
                </div>
                <div class="InputRowTitle" style="width: 532px">
                    <asp:GridView ID="gvEOI" runat="server" AutoGenerateColumns="False" CssClass="FontSmall"
                        GridLines="None" Width="555px">
                        <Columns>
                            <asp:BoundField DataField="long_description" HeaderText="Benefit Plan">
                                <FooterStyle BackColor="#F4EDE1" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BenefitLevel" HeaderText="Benefit Level" FooterText="Total">
                                <FooterStyle BackColor="#F4EDE1" Font-Bold="True" HorizontalAlign="Right" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="name" HeaderText="Applies To">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Cost" HeaderText="Your Cost">
                                <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                                <FooterStyle BackColor="#F4EDE1" Font-Bold="True" HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Core/Optional" DataField="Pending">
                                <HeaderStyle HorizontalAlign="Center" />
                                <FooterStyle BackColor="#F4EDE1" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="Datablank10" style="width: 554px;">
                    &nbsp;
                </div>
                <div id="dvDepTitle" runat="server" class="InputRowTitle" style="width: 556px">
                    <asp:Label ID="lblActiveDependents" runat="server" Text="Your Active Dependents"
                        CssClass="FontSmall10" Font-Bold="True" ForeColor="Blue"></asp:Label><br />
                    <asp:Label ID="lblNoDependent" runat="server" CssClass="FontSmall" Font-Bold="True"
                        ForeColor="Maroon" Text="You do not have any dependents in our system" Visible="False"></asp:Label>
                </div>
                <div id="dvDepGrid" runat="server" class="InputRowTitle" style="width: 532px">
                    <asp:GridView ID="gvDep" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                        CssClass="FontSmall" BorderWidth="1px" Width="555px" GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="FullName" HeaderText="Full Name">
                                <HeaderStyle BackColor="White" BorderColor="White" ForeColor="Black" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Relation" HeaderText="Relation">
                                <HeaderStyle BackColor="White" BorderColor="White" ForeColor="Black" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DOB" HeaderText="DOB">
                                <HeaderStyle BackColor="White" BorderColor="White" ForeColor="Black" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="effective_date" HeaderText="Begin Date">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle BackColor="White" BorderColor="White" ForeColor="Black" HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="Datablank10" style="width: 554px;">
                    &nbsp;
                </div>
                <div class="InputRowTitle" style="width: 556px" id="divBeneTitle" runat="server">
                    <asp:Label ID="Label2" runat="server" Text="Your Beneficiaries" CssClass="FontSmall10"
                        Font-Bold="True" ForeColor="Blue" Visible="False"></asp:Label>
                    <br />
                    <asp:Label ID="lblNoBeneficireies" runat="server" CssClass="FontSmall" Font-Bold="True"
                        ForeColor="Maroon" Text="You do not have any beneficiaries in our system" Visible="False"></asp:Label></div>
                <div class="InputRowTitle" style="width: 532px">
                    <asp:GridView ID="gvBenefit" runat="server" AutoGenerateColumns="False" CssClass="FontSmall"
                        GridLines="None" Width="555px">
                        <Columns>
                            <asp:BoundField DataField="cvrg_name" HeaderText="Benefit Plan">
                                <FooterStyle BackColor="#F4EDE1" />
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="name" HeaderText="Beneficiary" FooterText="Total">
                                <FooterStyle BackColor="#F4EDE1" Font-Bold="True" HorizontalAlign="Right" />
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="description" HeaderText="Relationship">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                                <FooterStyle BackColor="#F4EDE1" Font-Bold="True" HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="type_" HeaderText="Type">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Percentage" DataField="benefit_percent">
                                <HeaderStyle HorizontalAlign="Left" />
                                <FooterStyle BackColor="#F4EDE1" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div id="Div1" class="InputRowTitle" style="width: 535px">
                    &nbsp;</div>
                <div class="Datablank10" style="height: 10px; width: 546px;">
                    &nbsp;
                </div>
                <div id="Div2" class="InputRowTitle" style="width: 535px">
                    &nbsp;</div>
                <div class="Datablank10" style="height: 10px">
                    &nbsp;
                </div>
                <div id="Div3" class="InputRowTitle" style="width: 550px">
                </div>
                <div class="Datablank10" style="height: 10px">
                    &nbsp;
                </div>
            </div>
            <div class="DataPage" style="margin-top: 20px">
                <asp:Label ID="lblNoCvrg" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
<%--<meta http-equiv="Pragma" content="no-cache" />
<meta http-equiv="Expires" content="-1" />--%>
</html>
