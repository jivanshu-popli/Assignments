import Axios from "axios";

export function saveEmployeeList(employeeList) {
    debugger;
    return {
        type: "SAVE_EMPLOYEES",
        payload: employeeList
    }
}

export function deleteAllEmployees() {
    return {
        type: "DELETE_ALL_EMPLOYEES"
    }
}

export function deleteEmployees(employeeId) {
    return {
        type: "DELETE_EMPLOYEES",
        payload: employeeId
    }
}

export function loadEmployeeData() {
    return function(dispatch) {
        return Axios.get("http://localhost:3000/employees").then((response) => {
            dispatch(saveEmployeeList(response.data))
        });
    }
}