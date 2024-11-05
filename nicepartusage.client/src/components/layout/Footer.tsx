import { Container, Group, Anchor } from '@mantine/core';
import logo from '../../assets/logo.png';

const links = [
    { link: '#', label: 'Contact' },
    { link: '#', label: 'Privacy' },
    { link: '#', label: 'Blog' },
    { link: '#', label: 'Careers' },
];

const Footer = () => {
    const items = links.map((link) => (
        <Anchor<'a'>
            c='dimmed'
            key={link.label}
            href={link.link}
            onClick={(event) => event.preventDefault()}
            size='sm'
        >
            {link.label}
        </Anchor>
    ));

    return (
        <div className='footer'>
            <Container className='inner'>
                <img src={logo} style={{ height: 30 }} alt='npu-logo' />
                <Group className='links'>{items}</Group>
            </Container>
        </div>
    );
};

export default Footer;