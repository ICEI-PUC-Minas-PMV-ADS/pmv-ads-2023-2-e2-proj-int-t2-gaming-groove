const communityButtons = document.querySelectorAll(".user-communities-items");

communityButtons.forEach(communityButton => {
    const communityHidden = communityButton.querySelector(".hidden");

    communityButton.addEventListener("click", function() {
        communityButtons.forEach(button => {
            const hidden = button.querySelector(".hidden");
            hidden.style.display = 'none';
            button.classList.remove('ativo');
        });
        communityHidden.style.display = 'flex';
        communityButton.classList.add('ativo');
    });
});

