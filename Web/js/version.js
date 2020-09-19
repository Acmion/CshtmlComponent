if (location.pathname != "/")
{
    var versionAlertElement = document.createElement("div");
    versionAlertElement.innerHTML = 
    `
        <div class="container">
            <strong>WARNING: This documentation is outdated. <a href="/"> View current documentation here.</a></strong>  
        </div>
    `;
    versionAlertElement.className = "p-4 position-fixed fixed-bottom bg-warning";

    document.body.appendChild(versionAlertElement);
}