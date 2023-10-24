const communityButtons = document.querySelectorAll(".user-communities-items");
communityButtons.forEach(communityButton => {
    const communityHidden = communityButton.querySelector(".hidden");

    communityButton.addEventListener("click", function() {
        if (communityHidden.style.display === 'flex') {
            communityHidden.style.display = 'none';
        } else {
            communityHidden.style.display = 'flex';
        }
    });
});



communityButtons.forEach(button => {
    button.addEventListener("click", () => {
        const hiddenContent = button.querySelector(".hidden");

        if (hiddenContent.style.display === "flex") {
            hiddenContent.style.marginBottom = "20px";
        } else {
            hiddenContent.style.marginBottom = "0";
        }
    });
});