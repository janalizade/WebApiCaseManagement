function x(){
      
    //fetch('https://localhost:44355/api/customers')
    //      .then(res=>res.json())
            
    //     .then(data=>{
    //       let Customers=data.map(option => {option.firstName}    )
    //      document.getElementById("castablebody").innerHTML=Customers
    //    }
        
    //    );



        fetch('https://localhost:44355/api/customers')
        .then((res) => { return res.json() })
        .then((data) => {
            let result = `<h2> Random User Info From Jsonplaceholder API</h2>`;
            data.forEach((user) => {
                const { id, firstName, lastName,city  } = user
                result +=
                    `<div>
                     <h5> User ID: ${id} </h5>
                         <ul class="w3-ul">
                         <li> User FirstName : ${firstName}</li>
                         <li> User LastName: ${lastName} </li>
                         <li> User LastName: ${city} </li>
                         </ul>
                      </div>`;
                        document.getElementById('result').innerHTML = result;
                    });
                })
            }