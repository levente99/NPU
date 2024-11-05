import { useState } from 'react';
import {
    Container,
    Avatar,
    UnstyledButton,
    Group,
    Text,
    Menu,
    Tabs,
    Burger,
} from '@mantine/core';
import { useDisclosure } from '@mantine/hooks';
import logo from '../../assets/logo.png';
import { useNavigate } from 'react-router';

const user = {
    name: 'Levente Makszimus',
    email: 'max.levente99@gmail.com',
    image: 'https://raw.githubusercontent.com/mantinedev/mantine/master/.demo/avatars/avatar-2.png',
};

const tabs = [
    'NPU',
    'Elements'
];

const Header = () => {
    const [opened, { toggle }] = useDisclosure(false);
    const [, setUserMenuOpened] = useState(false);
    const navigate = useNavigate();

    const items = tabs.map((tab) => (
        <Tabs.Tab value={tab} key={tab} onClick={() => navigate(tab.toLowerCase())}>
            {tab}
        </Tabs.Tab>
    ));

    return (
        <div className='header'>
            <Container className='mainSection' size='md'>
                <Group justify='space-between'>
                    <img src={logo} style={{ height: 30 }} alt='npu-logo' />
                    <Burger opened={opened} onClick={toggle} hiddenFrom='xs' size='sm' />
                    <Menu
                        width={260}
                        position='bottom-end'
                        transitionProps={{ transition: 'pop-top-right' }}
                        onClose={() => setUserMenuOpened(false)}
                        onOpen={() => setUserMenuOpened(true)}
                        withinPortal
                    >
                        <Menu.Target>
                            <UnstyledButton
                                className='user'
                            >
                                <Group gap={7}>
                                    <Avatar src={user.image} alt={user.name} radius='xl' size={20} />
                                    <Text fw={500} size='sm' lh={1} mr={3}>
                                        {user.name}
                                    </Text>
                                </Group>
                            </UnstyledButton>
                        </Menu.Target>
                        <Menu.Dropdown>
                        </Menu.Dropdown>
                    </Menu>
                </Group>
            </Container>
            <Container size='md'>
                <Tabs
                    defaultValue="npu"
                    variant='outline'
                    visibleFrom='sm'
                    classNames={{
                        root: 'tabs',
                        list: 'tabsList',
                        tab: 'tab',
                    }}
                >
                    <Tabs.List>{items}</Tabs.List>
                </Tabs>
            </Container>
        </div>
    );
};

export default Header;