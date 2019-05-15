function checkTermDepx(depName) {
    var msg = 'Your Dependent ' + depName + ' will have no coverages. Do you want to remove this dependent?';
    var ok = confirm(msg);
    var hidTerm =  document.getElementById("<%= hidTerminatde.ClientID %>");
    if (ok)
        hidTerm.value = 'yes'
    else
        hidTerm.value = 'No';

    alert(hidTerm.value);

    // __doPostBack(null, null);
}

function checkTermDep(depName) {
    var ok = confirm('Do you wish to send the retiree an email?');
    var hid = eval(document.getElementById('hidTerminatde'));
    if (ok)
        hid.value = 'yes'
    else
        hid.value = 'No';
    alert(hid.value);
}