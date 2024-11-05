import { Badge, Card, Flex, Group, Image, Input, Loader, Rating, Text } from '@mantine/core';
import React, { useEffect, useState } from 'react';
import { FaSearch, FaUser } from 'react-icons/fa';
import useDebounce from '../../hooks/Debounce';
import { NpuCreation as NpuCreationModel } from '../../models';
import { Api } from '../../services/Api';

const NpuCreation = () => {
    const [npuCreations, setNpuCreations] = useState<NpuCreationModel[]>();
    const [loading, setLoading] = useState(false);
    const [elementSearch, setElementSearch] = useState<string>('');
    const debouncedSearchTerm = useDebounce(elementSearch, 1000);

    useEffect(() => {
        (async () => {
            setLoading(true);

            setNpuCreations(await Api.getNpuCreations(elementSearch));

            setLoading(false);
        })();
    }, [debouncedSearchTerm]);

    return (
        loading ?
            <Flex justify='center'><Loader color='red' /></Flex> :
            <>
                <Input
                    placeholder='Search for creations by element name'
                    leftSection={<FaSearch />}
                    value={elementSearch}
                    onChange={(event) => setElementSearch(event.currentTarget.value)}
                />
                <Flex
                    mt={20}
                    gap='md'
                    justify='flex-start'
                    align='flex-start'
                    direction='row'
                    wrap='wrap'
                >
                    {npuCreations && npuCreations.map(npu =>
                        <Card key={npu.id} shadow='sm' padding='lg' radius='md' style={{ maxWidth: 300, height: 350 }} withBorder>
                            <Card.Section>
                                <Image
                                    src={'data:image/png;base64,' + npu.fileData}
                                    height={160}
                                    alt='NPU'
                                    fit='contain'
                                />
                            </Card.Section>
                            <Group justify='space-between' mt='md' mb='xs'>
                                <Flex align='center' justify='space-between' w='100%'>
                                    <Text fw={500} w='100%'>{npu.title}</Text>
                                    <Badge leftSection={<FaUser />} w={150}>{npu.creator.userName}</Badge>
                                </Flex>
                                <Flex align='center' justify='space-between' w='100%'>
                                    <div>Creativity:</div>
                                    <Rating value={npu.scores.reduce((total, next) => total + next.creativityScore, 0) / npu.scores.length} />
                                </Flex>
                                <Flex align='center' justify='space-between' w='100%'>
                                    <div>Uniqueness:</div>
                                    <Rating value={npu.scores.reduce((total, next) => total + next.uniquenessScore, 0) / npu.scores.length} />
                                </Flex>
                            </Group>
                            <Text size='sm' c='dimmed'>
                                {npu.description}
                            </Text>
                        </Card>
                    )}
                </Flex>
            </>
    );
}

export default NpuCreation;