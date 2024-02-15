export default function flightReducer(flightStore = [{ flightNo: 1, flight: "AirAsia"}], action) {
    if (action.type == "DELETE_ALL_FLIGHTS") {
        return []
    }
    
    if (action.type == "SAVE_FLIGHTS") {
        return action.payload
    }
    
    if (action.type == "DELETE_FLIGHTS") {
        var newArray = flightStore.filter((flight) => {
            return flight.id != action.payload
        })
        
        return newArray;
    }
    
    return flightStore;
}