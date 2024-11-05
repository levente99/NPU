import { MantineProvider } from '@mantine/core';
import '@mantine/core/styles.css';
import React, { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';
import './index.css';
import routes from './routes';

createRoot(document.getElementById('root')!).render(
    <MantineProvider>
        <StrictMode>
            <BrowserRouter>
                {routes}
            </BrowserRouter>
        </StrictMode>
    </MantineProvider>
)
