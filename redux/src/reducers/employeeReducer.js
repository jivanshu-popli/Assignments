export default function employeeReducer(employeeStore = [], action) {
    if (action.type == "DELETE_ALL_EMPLOYEES") {
        return []
    }
    
    if (action.type == "SAVE_EMPLOYEES") {
        return action.payload
    }
    
    if (action.type == "DELETE_EMPLOYEES") {
        
        var newEmployeeList = employeeStore.filter((employee) => {
            if (employee.id != action.payload) {
                return JSON.parse(JSON.stringify(employee));
            }
        })
        
        return newEmployeeList;
    }
    
    return employeeStore;
}