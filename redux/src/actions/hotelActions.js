function saveEmployeeList(hotelList) {
    return {
        type: "SAVE_HOTELS",
        payload: hotelList
    }
}

function deleteAllHotels() {
    return {
        type: "DELETE_ALL_HOTELS"
    }
}

function deleteEmployees(hotelId) {
    return {
        type: "DELETE_HOTELS",
        payload: hotelId
    }
}