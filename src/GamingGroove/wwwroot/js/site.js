document.addEventListener("DOMContentLoaded", function () {
    const comentarioForm = document.getElementById("userComment-form");

    comentarioForm.addEventListener("submit", function (event) {
        event.preventDefault();

        const formData = new FormData(comentarioForm);

        fetch("/ComunidadePage/Comentar", {
            method: "POST",
            body: formData,
        })
        .then((response) => {
            if (response.ok) {
                
            } else {
                throw new Error("Erro ao comentar.");
            }
        })
        .catch((error) => {
            console.error(error);
        });
    });
});
