import { Container } from '@mantine/core';
import { ReactNode } from 'react';
import Footer from './Footer';
import Header from './Header';

interface LayoutProps {
    children?: ReactNode;
}

const Layout = ({ children }: LayoutProps) => {
    return (
        <div className='layout'>
            <Header />
            <Container style={{ padding: 20 }}>
                {children}
            </Container>
            <Footer />
        </div>
    );
}

export default Layout;