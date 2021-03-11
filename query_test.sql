CREATE TABLE transaksi (
    id INT(64) PRIMARY KEY,
    tanggal_order TIMESTAMP,
    status_pelunasan VARCHAR(255),
    tanggal_pembayaran TIMESTAMP
);

INSERT INTO transaksi VALUES (1, '2020-12-01 11:30:00', 'lunas', '2020-12-01 12:00:00');
INSERT INTO transaksi VALUES (2, '2020-12-02 10:30:00', 'pending', NULL);

CREATE TABLE detail_transaksi (
    id INT(64) PRIMARY KEY,
    id_transaksi INT(64),
    harga DECIMAL(64, 2),
    jumlah_barang DECIMAL(64, 2),
    sub_total DECIMAL(64, 2)
)

INSERT INTO detail_transaksi VALUES (1, 1, 10000, 2, 20000);
INSERT INTO detail_transaksi VALUES (2, 2, 10000, 2, 20000);
INSERT INTO detail_transaksi VALUES (3, 2, 2500, 2, 5000);


SELECT transaksi.id, transaksi.status_pelunasan status, transaksi.tanggal_pembayaran,
    SUM(detail_transaksi.sub_total) as total, SUM(detail_transaksi.jumlah_barang) as jumlah_barang
FROM transaksi
INNER JOIN detail_transaksi ON transaksi.id = detail_transaksi.id_transaksi
GROUP BY transaksi.id;