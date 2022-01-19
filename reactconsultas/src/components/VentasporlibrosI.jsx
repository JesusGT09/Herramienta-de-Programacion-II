import axios from 'axios'
import React, {Fragment,useEffect,useState} from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';

const VentasporlibrosI = ({ParamIdVenta}) => {

    const [data,setData]=useState([]);
    useEffect(()=>{
        axios.get(`https://localhost:44322/api/ServicioWebAPICore/VentaporLibrosId/${ParamIdVenta}`)
        .then(resp=>{
            setData(resp.data);
        })
        .catch(error=>{
            console.log(error);
        })
    },[ParamIdVenta]);
    
    var num_resgistros=data.length;
    var i=0;
    var total=0;


  return(
    <div>
        <table className='table table-dark'>
            <thead>
                <tr>
                    <th>Item</th>
                    <th>NUM_VTA</th>
                    <th>COD_LIBRO</th>
                    <th>NOM_LIBRO</th>
                    <th>CANTIDAD</th>
                    <th>PRECIO</th>
                    <th>Total</th>
                </tr>
            </thead>
            <tbody>
                {
                    data.map(item=>(
                        <tr>
                        <td>{++i}</td>
                        <td>{item.id_venta}</td>
                        <td>{item.id_libro}</td>
                        <td>{item.libro}</td>
                        <td>{item.cantidad}</td>
                        <td>{item.precio}</td>
                        <td>{item.total}</td>
                        <td className='visually-hidden'>{total+=item.total}</td>
                    </tr>
                    ))
                    
                }
            </tbody>
        </table>
        <br/>
        <h4>Suma Total :  <b>{total}</b></h4>
    </div>
  ) 
  
};

export default VentasporlibrosI;
