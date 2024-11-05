import React from 'react';
import { Outlet, Route, Routes } from 'react-router-dom';
import Layout from './components/layout/Layout';
import NpuCreation from './components/application/NpuCreation';
import Element from './components/application/Element';

const routes = (
    <Routes>
        <Route path='/*' element={<Layout><Outlet /></Layout>}>
            <Route path='' element={<NpuCreation />} />
            <Route path='npu' element={<NpuCreation />} />
            <Route path='elements' element={<Element />} />
        </Route>
    </Routes>
);

export default routes;