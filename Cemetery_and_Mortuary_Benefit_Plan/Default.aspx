<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Cemetery_and_Mortuary_Benefit_Plan.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="uk-background-muted">
<head runat="server">
    <title>Cemetery and Mortuary Benefit Plan</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />

    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <link rel="stylesheet"
        href="https://www.me-content.com/mec/system/compiledResources/frameworks/bootstrap/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.8.2/css/all.css"
        integrity="sha384-xVVam1KS4+Qt2OrFa+VdRUoXygyKIuNWUUUBZYv+n27STsJ7oDOHJgfF0bNKLMJF" crossorigin="anonymous" />
    <link rel="stylesheet"
        href="https://www.me-content.com/mec/system/compiledResources/UIKit/uikit/dist/css/uikit.min.css" />
    <script
        src="https://www.me-content.com/mec/system/compiledResources/frameworks/bootstrap/dist/js/bootstrap.bundle.min.js">
    </script>
    <script src="https://www.me-content.com/mec/system/compiledResources/UIKit/uikit/dist/js/uikit.min.js"></script>
    <script src="https://www.me-content.com/mec/system/compiledResources/UIKit/uikit/dist/js/uikit-icons.min.js">
    </script>
   
    <style>
        .benSection {
            border: 1px solid #cccccc;
            border-radius: 5px;
            overflow: hidden;
        }

        .benTitle {
            padding: 15px;
            background: #efefef;
            border-bottom: 1px solid #cccccc;
        }

        .benContent {
            padding: 0px 15px 15px 15px;
        }

        .benCollect {
            font-size: 1.2rem;
            border-bottom: 1px solid #cccccc;
            padding-bottom: 10px;
            margin-bottom: 10px;
        }

        .uk-input,
        .uk-select,
        .uk-textarea {
            border-radius: 3px;
        }

        .benPaddingTop {
            padding-top: 20px;
        }

        ul,
        li {
            margin: 0px !important;
        }

        select:invalid,
        input:invalid {
            color: gray;
            font-style: italic;
        }

        @media (min-width: 500px) {
            .uk-form-horizontal .uk-form-label {
                width: 200px;
                margin-top: 7px;
                float: left;
            }
        }

        @media (min-width: 500px) {

            .uk-form-horizontal .uk-form-controls {
                margin-left: 215px;
            }
        }

        .uk-table tbody td {
            text-align: center
        }

            .uk-table tbody td:first-child {
                text-align: left
            }

        .uk-table thead th {
            text-align: center
        }

            .uk-table thead th:first-child {
                text-align: left
            }

        .uk-table th {
            vertical-align: middle;
        }

        .uk-table thead th {
            background: #252525;
            color: white !important;
        }
    </style>
    <script>
        function submitBenForm() {
            if ($('#mortuarySelect')[0].checkValidity() && $('#CemeterySelect')[0].checkValidity() && $('#phoneCol')[0].checkValidity()) {
                UIkit.modal.confirm(
                    'Are you sure you want to submit a request to be contacted about Cemetery and Mortuary Benefits?', {
                        labels: {
                            cancel: 'Cancel',
                            ok: 'Yes, Submit'
                        }
                    }).then(function () {
                        console.log('Confirmed.')
                        UIkit.modal('#benConfirm', {
                            escClose: false,
                            bgClose: false
                        }).show();

                        UIkit.util.ready(function () {

                            var bar = document.getElementById('js-progressbar');

                            var animate = setInterval(function () {

                                bar.value += 2;
                                console.log('increment');

                                if (bar.value >= bar.max) {
                                    clearInterval(animate);
                                }

                            }, 100);
                            // test function to simulation other function completing the submission
                            setTimeout(function () {
                                $('#js-progressbar').attr('value', '100');
                            }, 20000);
                            console.log($('#mortuarySelect').val());
                            console.log($('#CemeterySelect').val());
                            console.log($('#emailCol').val());
                            console.log($('#phoneCol').val());
                            console.log($('#dtCol').val());

                        });
                        setTimeout(function () {
                            saveForm();
                        }, 1000)
                    }, function () {
                        console.log('Rejected.')
                    });
            } else {
                UIkit.modal.alert(
                    'All required fields have not been filled out. Please check your entries and try again.')
            }
        }

        function ineligiblePopup() {
            UIkit.modal.alert('We&apos;re sorry, you are not eligible for the Funeral &amp; Cemetery Benefit. This benefit requires you have 5-years of service with the Archdiocese of Los Angeles.').then(function () {
               console.log('Alert closed.');
               parent.OnHomeClick();
           });
        }

        function alreadySub() {
            UIkit.modal.alert('Thank you for your interest in the Funeral &amp; Cemetery benefit. We have already received your request from an earlier session. Therefore, there is no reason to submit another request.').then(function () {
               console.log('Alert closed.');
               parent.OnHomeClick();
           });
            
        }

        function movetoNext() {
            parent.OnHomeClick();
        }

        function DoSave() {

            var hid = document.getElementById("<%= hidNext.ClientID %>");
            hid.value = 'Go';
            PostBack()
        }

        function GoBack() {

            var hid = document.getElementById("<%= hidBack.ClientID %>");
            hid.value = 'Go';
            PostBack()
        }

        function PostBack() {
            var theForm = document.forms['form1'];
            if (!theForm) {
                theForm = document.form1;
            }
            if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
                theForm.submit();
            }
        }
        UIkit.util.on(document, 'beforeshow', '.uk-modal', function () {
            $('.uk-modal-dialog').addClass('uk-border-rounded uk-overflow-auto');
            $('.uk-modal-footer').find('.uk-button').addClass('uk-border-pill');
        });
        UIkit.util.on(document, 'hidden', '.uk-modal', function () {
            $('#js-progressbar').attr('value', '0');
        });
        $(document).on('change', 'select', function () {
            console.log($(this).val());
        })

        // demo logic for switching benefit tables. should be removed 
        $(document).on('change', '#benefitsTableSelect', function () {
            var tableSel = $('#benefitsTableSelect').val();
            if (tableSel == 0) {
                console.log('priest clicked');
                $('#benefitTableSection').load('./Tables/Priest.html', function () {
                    console.log('priest loaded');
                });
            } else if (tableSel == 1) {
                $('#benefitTableSection').load('./Tables/Religious.html', function () {
                    console.log('Religious loaded');
                });
            } else if (tableSel == 2) {
                $('#benefitTableSection').load('./Tables/Deacons.html', function () {
                    console.log('Deacons loaded');
                });
            } else if (tableSel == 3) {
                $('#benefitTableSection').load('./Tables/EmployeeFT.html', function () {
                    console.log('EmployeeFT loaded');
                });
            } else if (tableSel == 4) {
                $('#benefitTableSection').load('./Tables/EmployeePT.html', function () {
                    console.log('EmployeePT loaded');
                });
            }
        })

        function completeSubmit() {
            $('#js-progressbar').attr('value', '100');
            setTimeout(function () {
                console.log('call succeded');
                $('#benConfirm').find('.uk-modal-header').show('slow');
                $('#benConfirm').find('.uk-modal-footer').show('slow');
                $('#benConfirm').find('.uk-modal-close-default').show(
                    'slow');
                $('#loadingBdy').hide('slow');
                $('#confirmBdy').show('slow');
            }, 1500);
            $('#loadingTxt').css('color', '#32d296', function () {
                $('#loadingTxt').text('Success!');
            });
        }

        function completeSubmitFail() {
            $('#js-progressbar').attr('value', '100');
            UIkit.modal.confirm('There was a problem processing your request. Would you like to try again?', {
                labels: {
                    cancel: 'Skip to next step',
                    ok: 'Try again'
                }
            }).then(function () {
                console.log('Retry');
                location.reload();
            }, function () {
                console.log('Skip and move on');

            });
        }

        function saveForm() {

            $.ajax({
                type: "POST",
                url: "/web_projects/MyEnrollWebService/EmployeeWebMethod.aspx/insert_empl_funeral",
                data: JSON.stringify({
                    mortuary: $('#mortuarySelect').val(),
                    cemetery: $('#CemeterySelect').val(),
                    email: $('#emailCol').val(),
                    phone: $('#phoneCol').val(),
                    contact_pref: $('#dtCol').val()

                }),
                contentType: "application/json; charset=utf-8",
                success: function () {
                    console.log('Form submitted successfully');
                    completeSubmit();
                },
                error: function () {
                    $('#js-progressbar').attr('value', '100');
                    console.log('error thrown');
                    completeSubmitFail();
                }
            });
        }

        

        $(document).ready(function () {
            $('#benefitTableSection').load('./Tables/Priest.html');
        })
    </script>

</head>
<body class="uk-background-muted">
    <form id="form1" runat="server" class="uk-section-small uk-section-muted">
         <asp:HiddenField ID="hidClob" runat="server" />
        <asp:Label ID="lblScript" runat="server"></asp:Label>
        <div class="uk-border-rounded uk-box-shadow-large uk-container uk-container-small uk-section-default">
            <div class="">
                <div class="uk-section uk-section-small uk-padding-remove-bottom">
                    <div class="uk-container-small uk-container">
                        <h3 class="uk-margin-small-bottom">Cemetery and Mortuary Benefit Plan</h3>
                        <a href="#" uk-toggle="target: #benCMLearn">Learn More about these important &amp; valuable benefits
                        &amp; discounts...</a>
                    </div>

                </div>

                <!-- <div class="uk-section uk-section-small" style="padding: 20px 0px 20px 0px">
                    <div class="uk-container-small uk-container">
                        <button class="btn btn-block uk-border-pill btn-outline-primary" onclick="movetoNext(); return false;">
                            Skip this Benefit
                        </button>
                    </div>
                </div> -->

                <div class="uk-section uk-section-small uk-padding-remove-bottom benPaddingTop">
                    <div class="uk-container-small uk-container">
                        <form
                            class="needs-validation uk-border-rounded uk-box-shadow-large uk-padding-small uk-form-horizontal benSection"
                            id="formSubmission">
                            <legend class="uk-legend benCollect" style="font-size: 1rem"><b style="font-size: 1rem">Yes,</b> I
                            would like to be contacted about these
                            benefits!</legend>
                            <div class="uk-text-meta uk-margin-bottom">
                                Complete all the information below and click the Submit button. MyEnroll<sup>360</sup> will
                            provide
                            your information to the ADLA Office of Preplanning, then a representative will contact you
                            to dicuss your interest.
                            </div>
                            <div class="uk-margin-top-small uk-text-meta">
                                <b style="color: red">*</b> Required Information
                            </div>
                            <div class="form-group row">
                                <label for="mortuarySelect" class="col-sm-4 col-form-label"
                                    style="font-size: .95rem">
                                    Mortuary Choice</label>
                                <div class="col-sm-8">
                                    <select required class="form-control uk-box-shadow-hover-medium" id="mortuarySelect">
                                        <option value="" disabled selected hidden>Select a Mortuary</option>
                                        <option>Queen of Heaven</option>
                                        <option>All Souls</option>
                                        <option>Calvary</option>
                                        <option>San Fernando</option>
                                        <option>Santa Clara</option>
                                        <option>Holy Cross, Culver CIty</option>
                                    </select>
                                </div>

                                <div class="invalid-feedback">
                                    Please select a Mortuary
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="CemeterySelect" class="col-sm-4 col-form-label"
                                    style="font-size: .95rem">
                                    Cemetery Choice</label>
                                <div class="col-sm-8">
                                    <select required class="form-control uk-box-shadow-hover-medium" id="CemeterySelect">
                                        <option value="" disabled selected hidden>Select a Cemetery</option>
                                        <option>All Souls Cemetery &amp; Mortuary - 4400 Cherry Avenue, Long Beach CA 90807
                                        (562) 424-8601 allsouls@catholiccm.org</option>
                                        <option value="Assumption Cemetery">Assumption Cemetery - 1380 Fitzgerald Road, Simi
                                        Valley CA 93065 (805) 583-5825 assumption@catholiccm.org</option>
                                        <option value="Calvary Cemetery and Mortuary">Calvary Cemetery &amp; Mortuary - Los
                                        Angeles 4201 Whittier Boulevard, Los Angeles CA 90023 (323) 261-3106
                                        calvaryla@catholiccm.org</option>
                                        <option value="Calvary Cemetery Santa Barbara">Calvary Cemetery Santa Barbara - 199
                                        N. Hope Avenue, Santa Barbara CA 93110 (805) 687-8811 calvarysb@catholiccm.org
                                        </option>
                                        <option value="Good Shepherd Cemetery">Good Shepherd Cemetery - 43121 70th Street
                                        West, Lancaster CA 93536 (661) 722-0887 goodshepherd@catholiccm.org</option>
                                        <option value="Holy Cross Cemetery Pomona">Holy Cross Cemetery Pomona - 444 E.
                                        Lexington Avenue, Pomona CA 91766 (909) 627-3602 holycrosspom@catholiccm.org
                                        </option>
                                        <option value="Holy Cross Cemetery and Mortuary Culver City">Holy Cross Cemetery
                                        &amp; Mortuary Culver City - 5835 W. Slauson Avenue, Culver City CA 90230 (310)
                                        836-5500 holycrosscc@catholiccm.org</option>
                                        <option value="Queen of Heaven Cemetery">Queen of Heaven Cemetery &amp; Mortuary -
                                        2161 S. Fullerton Road, Rowland Heights CA 91748 (626) 964-1291
                                        queenofheaven@catholiccm.org</option>
                                        <option>Resurrection Cemetery - 966 N. Potrero Grande Drive, Rosemead CA 91770 (323)
                                        887-2024 resurrection@catholiccm.org</option>
                                        <option value="San Fernando Mission Cemetery">San Fernando Mission Cemetery &amp;
                                        Mission Hills Catholic Mortuary - 11160 Stranwood Avenue, Mission Hills CA 91345
                                        (818) 361-7387 sanfernando@catholiccm.org</option>
                                        <option value="Santa Clara Cemetery and Mortuary">Santa Clara Cemetery &amp;
                                        Mortuary - 2370 N. "H" Street, Oxnard CA 93036 (805) 485-5757
                                        sclara@catholiccm.org</option>
                                    </select>
                                </div>

                                <div class="invalid-feedback">
                                    Please select a Cemetery
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-4 col-form-label" style="font-size: .95rem">
                                    Email
                                </label>
                                <div class="col-sm-8">
                                    <input class="uk-input uk-box-shadow-hover-medium" id="emailCol" type="email"
                                        placeholder="Enter Email Address">
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-4 col-form-label" style="font-size: .95rem">
                                    Phone <b style="color: red">*</b>
                                </label>
                                <div class="col-sm-8">
                                    <input required class="uk-input uk-box-shadow-hover-medium" id="phoneCol" type="tel"
                                        placeholder="Enter Preferred Phone No.">
                                </div>
                                <div class="invalid-feedback">
                                    You must enter a valid phone number
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-sm-4 col-form-label" style="font-size: .95rem">
                                    Best Day(s) &amp; Time(s)
                                </label>
                                <div class="col-sm-8">
                                    <input class="uk-input uk-box-shadow-hover-medium" id="dtCol" type="text"
                                        placeholder="Enter Day(s) &amp; Time(s)">
                                </div>
                            </div>
                            <div class="uk-text-center uk-margin-small-top">
                                <button class="uk-button uk-button-primary uk-border-pill uk-width-1-2" type="button"
                                    onclick="submitBenForm(); return false;">
                                    Submit
                                </button>
                            </div>
                        </form>

                    </div>

                </div>
                <div class="uk-section uk-section-small benPaddingTop">
                    <div class="uk-container-small uk-container">
                        <h3 class="uk-margin-small-bottom uk-flex uk-flex-middle ">Benefits &amp; Discounts

                        <!-- <select class="uk-select uk-box-shadow-hover-medium ml-2" id="benefitsTableSelect"
                            style="width: auto;font-size: 1rem;">
                            <option value="0">Priest</option>
                            <option value="1">Religious</option>
                            <option value="2">Deacons</option>
                            <option value="3">Full Time</option>
                            <option value="4">Part Time</option>
                        </select> -->

                        </h3>
                        <asp:HiddenField ID="hidNext" runat="server" />
                        <asp:HiddenField ID="hidBack" runat="server" />
                        <div class="uk-border-rounded uk-box-shadow-large benSection" style="background: white">

                            <!-- pull in HTML from database here -->
                            <div id="benefitTableSection" runat="server">
                                <!-- load benefit table here -->

                            </div>
                        </div>
                    </div>

                </div>


            </div>
        </div>

        


        <div id="benConfirm" uk-modal>
            <div class="uk-modal-dialog uk-border-rounded uk-overflow-auto">
                <div class="uk-modal-header" style="display: none">
                    <h2 class="uk-text-success">Confirmation</h2>
                </div>
                <div class="uk-modal-body">

                    <!-- loading section. function up top to hide/show where necessary -->
                    <div id="loadingBdy">
                        <h4 id="loadingTxt">Submitting your request...
                        </h4>
                        <progress id="js-progressbar" class="uk-progress" value="0" max="100"></progress>
                    </div>

                    <!-- confirmation section -->
                    <div id="confirmBdy" style="display: none">
                        <p><b>Your request has been submitted.</b></p>
                        <p>
                            Someone from the Archdiocese of Los Angeles'
                        Funeral & Cemetery Preplanning will contact you, shortly.
                        </p>
                        <p>
                            By clicking <b>Next</b> below, we will open your elections' summary page, so you may complete the
                        enrollment process.
                        </p>
                    </div>


                </div>
                <div class="uk-modal-footer uk-text-center" style="display: none">
                    <button class="uk-button uk-button-primary uk-modal-close uk-border-pill" type="button"
                        onclick="movetoNext(); return false;">
                        Go Home</button>
                </div>
            </div>
        </div>
        <div id="benCMLearn" uk-modal>
            <div class="uk-modal-dialog uk-border-rounded uk-overflow-auto">
                <button class="uk-modal-close-default" type="button" uk-close></button>
                <div class="uk-modal-header">
                    <h3 class="">ADLA Cemetery and Mortuary Benefit Plan</h3>
                </div>
                <div class="uk-modal-body" uk-overflow-auto>
                    <p>
                        The Archdiocese is proud to provide a Funeral and Cemetery Benefit to all its employees as
                    recognition that our associates believe in and support the value of making funeral arrangements in
                    advance both for financial reasons as well as to spare other family members the experience of
                    planning a funeral.
                    </p>
                    <p>
                        However, the benefit is for both at-need and pre-need arrangements. All employees will be able to
                    apply for this benefit when they enroll or update their records during open enrollment. Your
                    position with the Archdiocese dictates your benefit in this program.
                    </p>
                    <p>
                        These benefits are available to Archdiocesan clergy and for actively working, full-time and part-time
                    employees and of the Archdiocese who have been employed for 5 years or more. Certain family members
                    of the clergy and employees also qualify for this benefit.
                    </p>
                    <p>
                        Employees will be able to apply for this benefit during open enrollment or anytime during the year by
                    returning to the benefit website. They may also call the cemetery/mortuary directly and schedule an
                    appointment with a counselor.
                    </p>

                </div>
                <div class="uk-modal-footer uk-text-center">
                    <button class="uk-button uk-button-primary uk-modal-close uk-border-pill" type="button">Close</button>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
