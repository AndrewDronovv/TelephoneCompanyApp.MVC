document.getElementById('SearchBtn').addEventListener('click', function () {
    const phoneNumber = document.getElementById('PhoneNumber').value;
    document.getElementById('PhoneNumber').value = '';


    axios.get('/Home/Search?phoneNumber=' + phoneNumber)
        .then(function (response) {
            console.log(response);
            document.getElementById('CancelSearchModal').click();
            document.getElementById('AbonentsTableWrapper').innerHTML = response.data;
        })
        .catch(function (error) {
            // обработка ошибки
            console.log(error);
        })
        .finally(function () {
            // выполняется всегда
        });
})