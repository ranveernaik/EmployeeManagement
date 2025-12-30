function loadEmployees() {
    authFetch('/api/employees')
        .then(res => {
            if (res.status === 401) {
                alert("Unauthorized. Please login again.");
                window.location.href = "/Account/Login";
            }
            return res.json();
        })
        .then(data => renderTable(data));
}

window.onload = loadEmployees;
