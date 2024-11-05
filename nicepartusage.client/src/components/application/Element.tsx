import { ActionIcon, Flex, Loader, Table } from '@mantine/core';
import React, { useEffect, useState } from 'react';
import { FaEdit, FaTrash } from 'react-icons/fa';
import { Element as ElementModel } from '../../models';
import { Api } from '../../services/Api';

const Element = () => {
    const [elements, setElements] = useState<ElementModel[]>();
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        (async () => {
            setLoading(true);

            setElements(await Api.getElements());

            setLoading(false);
        })();
    }, []);

    const rows = elements && elements.map(element => (
        <Table.Tr key={element.id}>
            <Table.Td>{element.name}</Table.Td>
            <Table.Td>{element.description}</Table.Td>
            <Table.Td>
                <Flex
                    gap='md'
                    direction='row'
                    wrap='wrap'
                >
                    <ActionIcon
                        variant='filled'
                        size='lg'
                        aria-label='edit'
                    >
                        <FaEdit />
                    </ActionIcon>
                    <ActionIcon
                        variant='filled'
                        size='lg'
                        aria-label='edit'
                        color='red'
                    >
                        <FaTrash />
                    </ActionIcon>
                </Flex>
            </Table.Td>
        </Table.Tr>
    ));

    return (
        loading ?
            <Flex justify='center'><Loader color='red' /></Flex> :
            <Flex
                mt={20}
                gap='md'
                justify='flex-start'
                align='flex-start'
                direction='row'
                wrap='wrap'
            >
                <Table>
                    <Table.Thead>
                        <Table.Tr>
                            <Table.Th>Name</Table.Th>
                            <Table.Th>Description</Table.Th>
                            <Table.Th>Actions</Table.Th>
                        </Table.Tr>
                    </Table.Thead>
                    <Table.Tbody>{rows}</Table.Tbody>
                </Table>
            </Flex>
    );
};

export default Element;