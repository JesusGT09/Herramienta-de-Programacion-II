import axios from 'axios'
import React, {Fragment,useEffect,useState} from 'react'
import 'bootstrap/dist/css/bootstrap.min.css';
import VentasporlibrosI from './VentasporlibrosI';

const Ventasporlibros = () => {

    const [data,setData]=useState([]);
    useEffect(()=>{
        axios.get('https://localhost:44322/api/ServicioWebAPICore/VentaporLibros')
        .then(resp=>{
            setData(resp.data);
        })
        .catch(error=>{
            console.log(error);
        })
    },[]);
     var num_resgistros=data.length;

     const [id_venta,setIdVenta]=useState("");
     function GetIdVenta(e){
         
         setIdVenta(e.target.value);
     };


  return(
    <div>
        <center>
        <h1>
        Libros Vendidos por Nro. Venta
        </h1>
        <br/>
        <hr/>
        <br/>
        <h3>Libros Vendidos por Nro. Venta {id_venta}</h3>
        <br/>
        <select name='cboventas' className='form-control' 
            value={id_venta} onChange={(e)=>GetIdVenta(e)}>
                {
                    data.map(item=>(
                        <option key={item.id_venta} value={item.id_venta}>
                            {item.id_venta}
                        </option>
                    ))
                }
            </select>
            <br/>
            </center>
            <Fragment>
                <VentasporlibrosI ParamIdVenta={id_venta}/>
            </Fragment>
    </div>
  )
  
};

export default Ventasporlibros;
