function saveEmployeeList(flightList) {
    return {
        type: "SAVE_FLIGHT",
        payload: flightList
    }
}

function deleteAllFlights() {
    return {
        type: "DELETE_ALL_FLIGHTS"
    }
}

function deleteEmployees(flightId) {
    return {
        type: "DELETE_FLIGHTS",
        payload: flightId
    }
}