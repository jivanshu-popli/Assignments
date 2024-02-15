export default function EmployeeInfo(props) {
    return (
       <div className="card" style={{ width: "18rem", display: "inline-block", margin: "10px", padding: "10px" }}>
           <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTRYWiJM9gMrv5z-T0IH7AIU0jk8NXRmTYhYGfpobi3ew&s" className="card-img-top" alt="Image" />
           <div className="card-body">
                <h5 className="card-title">{props.name} {props.id}</h5>
               <p className="card-text">Employee Created On: {props.createdAt}.</p>
               <input type="button" className="btn btn-primary" value="Delete" onClick={function () { props.deleteEmployee(props.id) }} />
           </div>
       </div>
   )
}