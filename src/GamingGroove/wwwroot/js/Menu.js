var menuIcon = document.getElementById("menu-icon");
var listMenu = document.getElementById("listMenu");
    
menuIcon.addEventListener("click", function() {
    if (listMenu.style.display === 'block') {
        listMenu.style.display = 'none';
    } else {
        listMenu.style.display = 'block';
    }
});

