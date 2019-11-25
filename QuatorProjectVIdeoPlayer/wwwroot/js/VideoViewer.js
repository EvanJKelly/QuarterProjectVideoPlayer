
async function AJAXSubmit(oFormElement) {
    var resultElement = oFormElement.elements.namedItem("result");
    const formData = new FormData(oFormElement);

    try {
        const response = await fetch(oFormElement.action, {
            method: 'POST',
            body: formData
        });

        if (response.ok) {
            window.location.href = '/';
        }

        resultElement.value = 'Result: ' + response.status + ' ' +
            response.statusText;
    } catch (error) {
        console.error('Error:', error);
    }
}
