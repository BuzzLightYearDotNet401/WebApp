console.log("linked");

let openRegister = document.getElementById("register-btn");
let registerForm = document.getElementById("register-section");
let closeRegister = document.getElementById("close-register");

openRegister.addEventListener("click", () => {
    console.log("open");
    registerForm.classList.toggle("hidden");
});

closeRegister.addEventListener("click", () => {
    console.log("close");
    registerForm.classList.toggle("hidden");
});