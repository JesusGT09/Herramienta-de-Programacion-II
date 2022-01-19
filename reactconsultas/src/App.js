import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import React from 'react';
import Inicio from './components/Inicio';
import Ventasporlibros from './components/Ventasporlibros';
import Librosporautores from './components/Librosporautores';
import {BrowserRouter as Router,Routes,Route,Link} from 'react-router-dom';

function App() {
  return (
    <Router>
      <div className='container mt-5'>
        <div className='btn-group'>
          <Link to="/" className='btn btn-success'>Inicio</Link>
          <Link to="/ListarVentasporLibro" className='btn btn-success'>Consulta 1</Link>
          <Link to="/ListarLibrosporAutores" className='btn btn-success'>Consulta 2</Link>
        </div>
        <hr/>
        <Routes>
          <Route path="/" exact element={<Inicio/>} />
          <Route path="/ListarVentasporLibro" element={<Ventasporlibros/>} />
          <Route path="/ListarLibrosporAutores" element={<Librosporautores/>} />
        </Routes>
      </div>
    </Router>

  );
}

export default App;

