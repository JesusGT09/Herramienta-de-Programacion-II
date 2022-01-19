import axios from 'axios'
import React, {Fragment,useEffect,useState} from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';

const LibrosporautoresI = ({ParamIdAutor}) => {
    

    const [data,setData]=useState([]);
    useEffect(()=>{
        axios.get(`https://localhost:44322/api/ServicioWebAPICore/AutoresporLibro/${ParamIdAutor}`)
        .then(resp=>{
            setData(resp.data);
        })
        .catch(error=>{
            console.log(error);
        })
    },[ParamIdAutor]);
    
    var num_resgistros=data.length;
    var i=0;
    var total_importe=0;
    return (
    <div>
        
        <br/>
        <hr/>
        <table className='table table-dark'>
            <thead>
                <tr>
                    <th>Item</th>
                    <th>COD_LIBRO</th>
                    <th>NOM_LIBRO</th>
                    <th>EDICION</th>
                    <th>PRE_LIBRO</th>
                    <th>STK_LIBRO</th>
                    <th>IMPORTE</th>
                </tr>
            </thead>
            <tbody>
                { 
                data.map(item=>(
                    <tr>
                    <td>{++i}</td>
                    <td>{item.idLibro}</td>
                    <td>{item.libro}</td>
                    <td>{item.edicion}</td>
                    <td>{item.precio}</td>
                    <td>{item.stock}</td>
                    <td>{item.importe}</td>
                    <td className='visually-hidden'>{total_importe+=item.importe}</td>
                </tr>
                ))  
                
                }
            </tbody>
        </table>
        <br/>
        <h4>Total de Importe :  <b>{total_importe}</b></h4>
        <br/>

    </div>
  )
};

export default LibrosporautoresI;
