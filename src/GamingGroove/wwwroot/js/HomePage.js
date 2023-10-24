const loginButton = document.getElementById("login");
const signupButton = document.getElementById("signup");
const loginCard = document.getElementById("login-card");
const signupCard = document.getElementById("signup-card");

loginButton.addEventListener("click", function () {
    loginCard.style.display = "block";
    signupCard.style.display = "none";
});

signupButton.addEventListener("click", function () {
    loginCard.style.display = "none";
    signupCard.style.display = "block";
});



