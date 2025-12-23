const API_BASE_URL = "https://thinkbridgebusfixes101.onrender.com";

document.addEventListener("DOMContentLoaded", function () {
    fetch(`${API_BASE_URL}/api/invoice`)
        .then(resp => {
            if (!resp.ok) {
                throw new Error("Failed to fetch invoice");
            }
            return resp.json();
        })
        .then(data => {
            let html = "<ul>";
            data.items.forEach(item => {
                html += `<li>${item.name} - ₹${item.price}</li>`;
            });
            html += "</ul>";
            document.getElementById("invoice-container").innerHTML = html;
        })
        .catch(err => console.error("Error loading invoice:", err));
});
